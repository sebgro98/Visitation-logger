import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useLocation, useNavigate } from "react-router-dom";
import { login } from "../services/apiClient";
import jwt_decode from "jwt-decode";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const navigate = useNavigate();
  const location = useLocation();
  const [token, setToken] = useState(localStorage.getItem("token"));
  const [user, setUser] = useState(null);

  useEffect(() => {
    const storedToken = localStorage.getItem("token");
    const storedUser = localStorage.getItem("user");

    if (storedToken && storedUser) {
      setToken(storedToken);
      setUser(storedUser);
      navigate(location.pathname || "/"); // This is a placeholder for the actual dashboard path "/dashboard" that will be implemented later
    } /* else {
      navigate("/");
    } */
  }, []);

  const handleLogin = async (username, password, isAdminMode) => {
    const res = await login(username, password, isAdminMode);

    console.log("Result from backend:", res);

    const decodedToken = jwt_decode(res.data.token);

    console.log("Decoded token:", decodedToken);

    /*  if (!res.data.token || !res.data.user) {
      return navigate("/");
    } */

    /* localStorage.setItem("token", res.data.token);
    localStorage.setItem("role", res.data.user);

    setToken(res.data.token);
    setUser(res.data.user); */

    // This is a placeholder for the actual admin dashboard that will be implemented later
    /*   if (isAdminMode) {
      navigate("/admin");
    } */

    // navigate("/"); // This is a placeholder for the actual dashboard path "/dashboard" that will be implemented later
  };

  const handleLogout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("role");
    setToken(null);
    setUser(null);
  };

  const value = {
    token,
    user,
    onLogin: handleLogin,
    onLogout: handleLogout,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

AuthProvider.propTypes = {
  children: PropTypes.node,
};

export { AuthContext, AuthProvider };
