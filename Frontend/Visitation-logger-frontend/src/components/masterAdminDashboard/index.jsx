import {
  faDownload,
  faUser as faUserSolid,
  faTools,
} from "@fortawesome/free-solid-svg-icons";
import { faUser as faUserRegular } from "@fortawesome/free-regular-svg-icons";
import DashboardHeader from "../dashboardHeader";
import DashboardAction from "../dashboardAction";

const MasterAdminDashboard = () => {
  return (
    <>
      <DashboardHeader
        title="Masteradministratör"
        info="Som masteradministratör så kan du visa/exportera samtliga besökloggarningar. Du kan även hantera gäst- och adminkonton"
      />
      <div className="dashboard-actions">
        <DashboardAction
          to="/dashboard"
          icons={[faDownload]}
          title="Visa/Exportera besöksloggningar"
          info="Klicka på ikonen ovan för att visa/exportera besöksloggningar"
        />
        <DashboardAction
          to="/manage-visitors"
          icons={[faUserRegular, faTools]}
          title="Hantera gästkonton"
          info="Klicka på ikonen ovan för att hantera gästkonton"
        />
        <DashboardAction
          to="/manage-admins"
          icons={[faUserSolid, faTools]}
          title="Hantera adminkonton"
          info="Klicka på ikonen ovan för att hantera adminkonton"
        />
      </div>
    </>
  );
};

export default MasterAdminDashboard;
