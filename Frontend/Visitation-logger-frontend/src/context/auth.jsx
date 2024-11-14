import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useLocation, useNavigate } from "react-router-dom";
import { login } from "../services/apiClient";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const navigate = useNavigate();
  const location = useLocation();
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    const storedToken = localStorage.getItem("token");

    if (storedToken) {
      navigate(location.pathname || "/"); // This is a placeholder for the actual dashboard path "/dashboard" that will be implemented later
      setIsLoggedIn(true);
    } /* else {
      setIsLoggedIn(false);
      navigate("/");
    } */ // This is for when a user is not logged in and should be redirected to the role selection page
  }, []);

  const handleLogin = async (username, password, isAdminMode) => {
    const res = await login(username, password, isAdminMode);

    if (!res.token) {
      return navigate("/");
    }

    localStorage.setItem("token", res.token);
    setIsLoggedIn(true);

    // This is a placeholder for the actual admin dashboard that will be implemented later
    /*   if (isAdminMode) {
      navigate("/admin");
    } */

    // navigate("/"); // This is a placeholder for the actual dashboard path "/dashboard" that will be implemented later
  };

  const handleLogout = () => {
    localStorage.removeItem("token");
    setIsLoggedIn(false);
    navigate("/");
  };

  const value = {
    isLoggedIn,
    onLogin: handleLogin,
    onLogout: handleLogout,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

AuthProvider.propTypes = {
  children: PropTypes.node,
};

export { AuthContext, AuthProvider };
