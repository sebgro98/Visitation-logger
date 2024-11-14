import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faDownload } from "@fortawesome/free-solid-svg-icons";
import "./loggAdminDashboard.css";

const LoggAdminDashboard = () => {
  return (
    <div className="logg-admin-dashboard">
      <div className="-logg-dashboard-header">
        <h1 className="dashboard-header-title">Loggadministratör</h1>
        <p className="dashboard-header-info">
          Som loggadministratör så kan du visa/exportera samtliga
          besökloggarningar.
        </p>
      </div>
      <div className="dashboard-action">
        <Link
          onClick={() => {
            console.log("Länken till loggsidan har klickats!");
          }}
          to="/dashboard"
        >
          <FontAwesomeIcon icon={faDownload} className="dashboard-icon" />
        </Link>
        <div className="dashboard-action-header">
          <h2 className="dashboard-action-header-title">
            Visa/Exportera besöksloggningar
          </h2>
          <p className="dashboard-action-header-info">
            Klicka på ikonen ovan för att visa/exportera besöksloggningar
          </p>
        </div>
      </div>
    </div>
  );
};

export default LoggAdminDashboard;
