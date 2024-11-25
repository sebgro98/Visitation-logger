import DashboardAction from "../dashboardAction";
import DashboardHeader from "../dashboardHeader";
import { faUserPlus, faUserTimes } from "@fortawesome/free-solid-svg-icons";
const VisitorDashboard = () => {
  return (
    <>
      <DashboardHeader
        title="Besökare/Visitor"
        info="Samtliga besökare som inte har behörighet att vistas i lokalen behöver checkas in via denna sida"
      />
      <div className="dashboard-actions">
        <DashboardAction
          to="/dashboard"
          onClick={() => console.log("Länken till checka in har klickats!")}
          icons={[faUserPlus]}
          title="Checka in besökare"
          info="Klicka på ikonen ovan för att checka in. Är det första gången du checkar in var vänlig fyll i besöksformuläret"
        />
        <DashboardAction
          to="/dashboard"
          onClick={() => console.log("Länken till checka ut har klickats!")}
          icons={[faUserTimes]}
          title="Checka ut besökare"
          info="Klicka på ikonen ovan för att checka ut"
        />
      </div>
    </>
  );
};

export default VisitorDashboard;
