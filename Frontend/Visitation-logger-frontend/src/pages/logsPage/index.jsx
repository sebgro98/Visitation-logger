import { useEffect, useState } from "react";
import "./logsPage.css";
import Modal from "../../components/modal";
import Table from "../../components/table";
import Button from "../../components/button";
import "../../services/apiClient";
import { getStatusByPage } from "../../services/apiClient";

const Logs = () => {
  const [logs, setLogs] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [isModalOpen, setIsModalOpen] = useState(false);
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
            const data = await getStatusByPage(filter);
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
      const data = await getStatusByPage({ ...filter, pageNumber: 1, pageSize: numberOfElements });
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

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  const applyFilter = async () => {
    try {
      const data = await getStatusByPage(filter);
      setLogs(data.statusList);
      setNumberOfPages(data.totalNumberOfPages);
      setNumberOfElements(data.totalNumberOfElements);
      toggleModal();
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }

  return (
    <>

      <div className="logsPage-results">
      <div className="logsPage-header">
        <Button label={"Filtrera"} onClick={toggleModal} />
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
        <Modal isOpen={isModalOpen} onClose={toggleModal}>
          <div className="logsPage-filter-body">
            <h2>Filterera loggarna</h2>
            <input
              className="logsPage-filter-visitorName"
              type="text"
              placeholder={filter.visitorName ? filter.visitorName : "Besökare"} 
              onChange={e => setFilter({ ...filter, visitorName: e.target.value })}
              />
            <input
              className="logsPage-filter-visitorId"
              type="text"
              placeholder={filter.visitorId ? filter.visitorId : "BesökarId"}
              onChange={e => setFilter({ ...filter, visitorId: e.target.value })}
              />
            <input
              className="logsPage-filter-purpose"
              type="text"
              placeholder={filter.purposeName ? filter.purposeName : "Besöksbeskrivning"}
              onChange={e => setFilter({ ...filter, purposeName: e.target.value })}
              />
            <input
              className="logsPage-filter-node"
              type="text"
              placeholder={filter.node ? filter.node : "Nod"}
              onChange={e => setFilter({ ...filter, node: e.target.value })}
              />
            <div className="logsPage-filter-dates">
                <input
                  type="date"
                  placeholder={filter.checkInTime ? filter.checkInTime : "Incheckning"}
                  onChange={e => setFilter({ ...filter, checkInTime: e.target.value })}
                  />
                <input
                  type="date"
                  placeholder={filter.checkOutTime ? filter.checkOutTime : "Utcheckning"}
                  onChange={e => setFilter({ ...filter, checkOutTime: e.target.value })}
                  />
              </div>
            </div>
          <br></br>
          <div className="logsPage-filter-footer">
            <Button label={"Filtrera"} onClick={applyFilter} />
            <Button label={"Rensa"} onClick={() => setFilter({ ...filter, visitorName: "", visitorId: "", purposeName: "", node: "", checkInTime: "", checkOutTime: "" })} /> 
          </div>
        </Modal>
    </>
  );
};

export default Logs;

