import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import { login } from "../services/apiClient";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const navigate = useNavigate();
  const location = useLocation();
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    const storedToken = localStorage.getItem("token");

    if (storedToken) {
      navigate(location.pathname || "/dashboard");
      setIsLoggedIn(true);
    } /* else {
      setIsLoggedIn(false);
      navigate("/");
    } */ // This is for when a user is not logged in and should be redirected to the role selection page
  }, []);

  const handleLogin = async (username, password, isAdminMode) => {
    const res = await login(username, password, isAdminMode);
    console.log(res.token);

    if (!res.token) {
      return { token: null, error: res.error || "Login failed." };
    }
    localStorage.setItem("token", res.token);
    setIsLoggedIn(true);

    navigate("/dashboard");
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

// eslint-disable-next-line react/prop-types
const ProtectedRoute = ({ children }) => {
  const storedToken = localStorage.getItem("token");
  const location = useLocation();
  if (!storedToken) {
    return <Navigate to={"/"} replace state={{ from: location }} />;
  }

  return <>{children}</>;
};

export { AuthContext, AuthProvider, ProtectedRoute };
