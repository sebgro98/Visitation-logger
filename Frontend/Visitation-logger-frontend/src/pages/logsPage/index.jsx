import { useEffect, useState } from "react";
import LogEntry from "./logEntry";
import LogsPageButton from "./logsPage-button";
import "./logsPage.css";
import dummyLogs from "./dummylogs";

const Logs = () => {
  const [logs, setLogs] = useState([]);
  const [filteredLogs, setFilteredLogs] = useState([]);
  const [displayedLogs, setDisplayedLogs] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    setLogs(dummyLogs);
    setFilteredLogs(dummyLogs);
  }, []);

  useEffect(() => {
    paginate();
  }, [filteredLogs, currentPage]);

  const paginate = () => {
    const logsPerPage = 10;
    const lastLogIndex = Math.min(currentPage * logsPerPage, filteredLogs.length);
    const firstLogIndex = lastLogIndex - logsPerPage;

    const currentLogs = filteredLogs.slice(firstLogIndex, lastLogIndex);
    setDisplayedLogs(currentLogs);
  };

  const previousLogPage = () => {
    if (currentPage > 1) {
      setCurrentPage(currentPage - 1);
    }
  };

  const nextLogPage = () => {
    if (currentPage < Math.ceil(filteredLogs.length / 10)) {
      setCurrentPage(currentPage + 1);
    }
  };

  const exportToCSV = () => {
    const header = ["Besökare", "Besöksbeskrivning", "Nod", "Datum"];
    const rows = logs.map(log => [
      log.visitor,
      log.description,
      log.node,
      log.date
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

  const filter = () => {
    console.log("Filter logs");
  };

  return (
    <div className="logsPage">
      <div className="logsPage-header">
        <LogsPageButton name={"Filtrera"} onClick={filter} />
        <LogsPageButton name={"Exportera"} onClick={exportToCSV} />
      </div>
      <div className="logsPage-results">
        <table className="logsPage-table">
          <thead>
            <tr>
              <th>Besökare</th>
              <th>Besöksbeskrivning</th>
              <th>Nod</th>
              <th>Datum</th>
            </tr>
          </thead>
          <tbody>
            {displayedLogs.map((log, index) => (
              <LogEntry log={log} key={index} index={index} />
            ))}
          </tbody>
        </table>
      </div>
      <div className="logsPage-footer">
        <LogsPageButton name={"Föregående"} onClick={previousLogPage} />
        <LogsPageButton name={"Nästa"} onClick={nextLogPage} />
      </div>
    </div>
  );
};

export default Logs;

