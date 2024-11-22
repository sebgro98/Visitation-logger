import { faDownload } from "@fortawesome/free-solid-svg-icons";
import DashboardHeader from "../dashboardHeader";
import DashboardAction from "../dashboardAction";

const LoggAdminDashboard = () => {
  return (
    <>
      <DashboardHeader
        title="Loggadministratör"
        info="Som loggadministratör så kan du visa/exportera samtliga besökloggarningar."
      />
      <div className="dashboard-actions">
        <DashboardAction
          to="/logs"
          icons={[faDownload]}
          title="Visa/Exportera besöksloggningar"
          info="Klicka på ikonen ovan för att visa/exportera besöksloggningar"
        />
      </div>
    </>
  );
};

export default LoggAdminDashboard;
