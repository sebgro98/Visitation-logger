import { useEffect, useState } from "react";
import LogEntry from "./logEntry";

const Logs = () => {
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    // Define the dummy logs
    const dummyLogs = [
      {
        visitor: "Anna Karlsson",
        description: "Besök för systemuppdatering",
        node: "SESTO1",
        date: "2024-11-01"
      },
      {
        visitor: "Johan Rysk",
        description: "Teknisk felsökning",
        node: "SEGOT3",
        date: "2024-11-02"
      },
      {
        visitor: "Emma Persson",
        description: "Underhållsarbete",
        node: "SEMAL10",
        date: "2024-11-03"
      },
      {
        visitor: "Lars Svensson",
        description: "Systemtestning",
        node: "NOOSL3",
        date: "2024-11-04"
      },
      {
        visitor: "Sara Lindgren",
        description: "Programuppdatering",
        node: "SEUPP5",
        date: "2024-11-05"
      }
    ];

    // Set the logs in state
    setLogs(dummyLogs); // Initialize logs with dummy data on first render
  }, []); // Empty dependency array ensures this runs only once when the component mounts

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
    link.href = URL.createObjectURL(blob);
    link.download = "logs.csv"; // Set the file name for the download
    link.click(); // Trigger the download
  };

  return (
    <>
      <div className="logsPage-header">
        <button className="logsPage-filter" type="button">
          Filtrera
        </button>
        <button className="logsPage-export" onClick={exportToCSV}>
          Exportera
        </button>
      </div>
      <div className="logsPage-results">
        <table>
          <thead>
            <tr>
              <th>Besökare</th>
              <th>Besöksbeskrivning</th>
              <th>Nod</th>
              <th>Datum</th>
            </tr>
          </thead>
          <tbody>
            {logs.map((log, index) => (
              <LogEntry log={log} key={index} />
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};

export default Logs;
