import PropTypes from "prop-types";
import "./login.css";
import { faLock, faUser } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import useAuth from "../../hooks/useAuth";
import { useState } from "react";

const Login = ({ isAdminMode }) => {
  const { onLogin } = useAuth();
  const [error, setError] = useState("");
  const [formData, setFormData] = useState({ username: "", password: "" });

  const onChange = (e) => {
    setError("");
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!formData.username || !formData.password) {
      setError("Användarnamn och lösenord får inte vara tomma.");
      return;
    }

    if (formData.username.includes(" ") || formData.password.includes(" ")) {
      setError("Kontrollera input, inga mellanslag är tillåtna.");
      return;
    }

    const result = await onLogin(
      formData.username,
      formData.password,
      isAdminMode
    );

    if (result && result.error) {
      setError(result.error);
    }
  };

  return (
    <main>
      <div className="main-login-card">
        <h2 className="login-header">Logga In</h2>
        <p className="login-role-description">
          Loggar in som {isAdminMode ? "administratör" : "besökare"}
        </p>
        <form className="login-form" onSubmit={handleSubmit}>
          <div className="input-container">
            <span className="input-icon">
              <FontAwesomeIcon icon={faUser} />
            </span>
            <input
              type="text"
              id="username"
              name="username"
              placeholder="Användarnamn"
              onChange={onChange}
              value={formData.username}
            />
          </div>
          <div className="input-container">
            <span className="input-icon">
              <FontAwesomeIcon icon={faLock} />
            </span>
            <input
              type="password"
              id="password"
              name="password"
              placeholder="Lösenord"
              onChange={onChange}
              value={formData.password}
            />
          </div>
          <button type="submit">Logga in</button>
        </form>
        <p className={`error-message ${error ? "visible" : ""}`}>{error}</p>
      </div>
    </main>
  );
};

Login.propTypes = {
  isAdminMode: PropTypes.bool.isRequired,
};

export default Login;
