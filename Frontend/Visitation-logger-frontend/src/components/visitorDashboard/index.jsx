import { useEffect } from "react";
import DashboardAction from "../dashboardAction";
import DashboardHeader from "../dashboardHeader";
import { faUserPlus, faUserTimes } from "@fortawesome/free-solid-svg-icons";

import jwt_decode from "jwt-decode";
import { getVisitorAccountById } from "../../services/apiClient";
import { useNavigate } from "react-router-dom";
const VisitorDashboard = () => {
  const { token } = localStorage;
  const navigate = useNavigate();

  useEffect(() => {
    /*     try {
      const visitorProfile = getVisitorAccountById(nameid);
      console.log("Visitor profile", visitorProfile);
    } catch (error) {
      console.error("Error parsing visitor data", error);
    } */
  }, []);

  const handleClick = () => {
    console.log("Token:", token);
    if (token) {
      console.log("Navigating to /visitor-form");
      navigate("/visitor-form");
    } else {
      console.log("Navigating to /dashboard");
      navigate("/dashboard");
    }
  };

  return (
    <>
      <DashboardHeader
        title="Besökare/Visitor"
        info="Samtliga besökare som inte har behörighet att vistas i lokalen behöver checkas in via denna sida"
      />
      <div className="dashboard-actions">
        <DashboardAction
          to="/visitor-form"
          icons={[faUserPlus]}
          title="Checka in besökare"
          info="Klicka på ikonen ovan för att checka in. Är det första gången du checkar in var vänlig fyll i besöksformuläret"
        />
        <DashboardAction
          to="/dashboard"
          icons={[faUserTimes]}
          title="Checka ut besökare"
          info="Klicka på ikonen ovan för att checka ut"
        />
      </div>
    </>
  );
};

export default VisitorDashboard;
