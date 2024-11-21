import { useEffect, useState } from "react";
import "./logsPage.css";
import Table from "../../components/table";
import Button from "../../components/button";
import "../../services/apiClient";
import { getPage } from "../../services/apiClient";

const Logs = () => {
  const [logs, setLogs] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [filter, setFilter] = useState(
    {
      pageSize: 10,
      pageNumber: currentPage,
      visitorName: "",
      visitorId: "",
      purposeName: "",
      node: "",
      checkInTime: "",
      checkOutTime: ""
    });

  useEffect(() => {
    const fetchData = async () => {
        try {
            const data = await getPage(filter);
            setLogs(data.statusList);
            setFilter({...filter, data});
            setNumberOfPages(data.totalNumberOfPages);     
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    };

    fetchData();
  }, [currentPage]);

  const previousLogPage = () => {
    if (currentPage !== 1) {
      setCurrentPage(currentPage - 1);
      setFilter({ ...filter, pageNumber: filter.pageNumber - 1 });
    }
  };

  const nextLogPage = () => {
    if (currentPage !== numberOfPages) {
      setCurrentPage(currentPage + 1);
      setFilter({ ...filter, pageNumber: filter.pageNumber + 1 });
    }
  };

  const exportToCSV = () => {
    const header = ["Besökare", "Besökar ID", "Besöksbeskrivning", "Nod", "Checka in", "Checka ut"];
    const rows = logs.map(log => [
      log.visitorName,
      log.visitorId,
      log.purpose,
      log.node,
      log.checkInTime,
      log.checkOutTime
    ]);

    const csvContent = [
      header.join(","),
      ...rows.map(row => row.join(","))
    ].join("\n");

    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const link = document.createElement("a");
    const currentdate = new Date();
    const datetime = currentdate.toISOString();
    link.href = URL.createObjectURL(blob);
    link.download = `logs_${datetime}.csv`;
    link.click();
  };

  const applyFilter = () => {
    console.log("Filter logs");
  };

  return (
    <>

      <div className="logsPage-results">
      <div className="logsPage-header">
        <Button label={"Filtrera"} onClick={applyFilter} />
        <Button label={"Exportera"} onClick={exportToCSV} />
      </div>
        <Table
          headers={["visitorName", "visitorId", "purposeName", "node", "checkInTime", "checkOutTime"]}
          data={logs}
          onRowClick={log => console.log(log)}
        />
      </div>
        <div className="logsPage-footer">
          <br></br>
          <Button
            label={"Föregående"}
            onClick={previousLogPage}
            disabled={currentPage === 1}
          />
          <Button
            label={"Nästa"}
            onClick={nextLogPage}
            disabled={currentPage === numberOfPages}
          />
      </div>
    </>
  );
};

export default Logs;

