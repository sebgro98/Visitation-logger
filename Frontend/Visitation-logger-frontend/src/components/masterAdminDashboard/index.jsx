import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faDownload,
  faUser as faUserSolid,
  faTools,
} from "@fortawesome/free-solid-svg-icons";
import { faUser as faUserRegular } from "@fortawesome/free-regular-svg-icons";
import "./masterAdminDashboard.css";

const MasterAdminDashboard = () => {
  return (
    <div className="logg-admin-dashboard">
      <div className="dashboard-header">
        <h1 className="dashboard-header-title">Masterdministratör</h1>
        <p className="dashboard-header-info">
          Som masteradministratör så kan du visa/exportera samtliga
          besökloggarningar. Du kan även hantera gäst- och adminkonton
        </p>
      </div>
      <div className="master-dashboard-actions">
        <div className="master-dashboard-action">
          <Link
            onClick={() => {
              console.log("Länken till loggsidan har klickats!");
            }}
            to="/dashboard"
          >
            <FontAwesomeIcon icon={faDownload} className="dashboard-icon" />
          </Link>
          <div className="master-dashboard-action-header">
            <h2 className="dashboard-action-header-title">
              Visa/Exportera besöksloggningar
            </h2>
            <p className="dashboard-action-header-info">
              Klicka på ikonen ovan för att visa/exportera besöksloggningar
            </p>
          </div>
        </div>
        <div className="master-dashboard-action">
          <Link
            onClick={() => {
              console.log("Länken till gästkontosidan har klickats!");
            }}
            to="/dashboard"
          >
            <div className="icon-container">
              <FontAwesomeIcon
                icon={faUserRegular}
                className="dashboard-icon"
              />
              <FontAwesomeIcon icon={faTools} className="dashboard-icon" />
            </div>
          </Link>
          <div className="master-dashboard-action-header">
            <h2 className="dashboard-action-header-title">
              Hantera gästkonton
            </h2>
            <p className="dashboard-action-header-info">
              Klicka på ikonen ovan för att hantera gästkonton
            </p>
          </div>
        </div>
        <div className="master-dashboard-action">
          <Link
            onClick={() => {
              console.log("Länken till adminkontosidan har klickats!");
            }}
            to="/dashboard"
          >
            <div className="icon-container">
              <FontAwesomeIcon icon={faUserSolid} className="dashboard-icon" />
              <FontAwesomeIcon icon={faTools} className="dashboard-icon" />
            </div>
          </Link>
          <div className="master-dashboard-action-header">
            <h2 className="dashboard-action-header-title">
              Hantera adminkonton
            </h2>
            <p className="dashboard-action-header-info">
              Klicka på ikonen ovan för att hantera adminkonton
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MasterAdminDashboard;
