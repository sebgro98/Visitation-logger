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
  const [numberOfElements, setNumberOfElements] = useState(0);
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
            setNumberOfElements(data.totalNumberOfElements);  
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

  const exportToCSV = async () => {
    try {
      const data = await getPage({ ...filter, pageNumber: 1, pageSize: numberOfElements });
      const rows = data.statusList;



      const csvContent = [
        ["Besökare", "BesökarId", "Besöksbeskrivning", "Nod", "Incheckning", "Utcheckning"],
        ...rows.map(row => [
          row.visitorName,
          row.visitorId,
          row.purposeName,
          row.node.nodeName,
          row.checkInTime,
          row.checkOutTime
        ])
      ].map(e => e.join(",")).join("\n");

      const timeSuffix = new Date().toISOString().replace(/:/g, "-").split(".")[0];

      const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
      const link = document.createElement("a");
      link.href = URL.createObjectURL(blob);
      link.setAttribute("download", "logs.csv" + timeSuffix);
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);

      console.log("Exporting logs to CSV", rows);
    } catch (error) {
      console.error("Error fetching data for exportation:", error);
    }
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

