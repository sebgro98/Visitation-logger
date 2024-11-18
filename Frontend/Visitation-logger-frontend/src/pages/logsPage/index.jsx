import { useEffect, useState } from "react";
import LogEntry from "./logEntry";
import LogsPageButton from "./logsPage-button";
import "./logsPage.css";
import dummyLogs from "./dummylogs";

const Logs = () => {
  const [logs, setLogs] = useState([]);
  const [filteredLogs, setFilteredLogs] = useState([]);

  useEffect(() => {

    //TODO: Fetch logs from the backend
    setLogs(dummyLogs);
    setFilteredLogs(dummyLogs); 
  }, []);

  // Function to convert logs to CSV format
  const exportToCSV = () => {
    const header = ["Besökare", "Besöksbeskrivning", "Nod", "Datum"];
    const rows = logs.map(log => [
      log.visitor,
      log.description,
      log.node,
      log.date
    ]);

    // Combine header and rows into a single CSV string
    const csvContent = [
      header.join(","),
      ...rows.map(row => row.join(","))
    ].join("\n");

    // Create a Blob from the CSV string and create a downloadable URL
    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const link = document.createElement("a");
    const currentdate = new Date(); 
    const datetime = currentdate.getMilliseconds();
    link.href = URL.createObjectURL(blob);
    link.download = "logs.csv" + datetime; // Set the file name for the download
    link.click(); // Trigger the download
  };

  const filter = () => {
    console.log("Filter logs");
    
  }

  const previousLogPage = () => {
    console.log("Previous log page");
  };

  const nextLogPage = () => {
    console.log("Next log page");
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
            {filteredLogs.map((log, index) => (
              <LogEntry log={log} key={index} index={index}/>
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
