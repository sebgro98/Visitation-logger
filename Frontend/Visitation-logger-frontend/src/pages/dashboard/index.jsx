import jwt_decode from "jwt-decode";
import LoggAdminDashboard from "../../components/loggAdminDashboard";
import "./dashboard.css";
import MasterAdminDashboard from "../../components/masterAdminDashboard";
import VisitorDashboard from "../../components/visitorDashboard";

const Dashboard = () => {
  const storedToken = localStorage.getItem("token");
  const decryptedToken = jwt_decode(storedToken);
  const role = decryptedToken.role;

  return (
    <main>
      {role === "Visitor" ? (
        <VisitorDashboard />
      ) : role === "LoggAdmin" ? (
        <LoggAdminDashboard />
      ) : (
        <MasterAdminDashboard />
      )}
    </main>
  );
};

export default Dashboard;
