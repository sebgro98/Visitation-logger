import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAddressCard, faUsersCog } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";
import "./roleSelection.css";
import { Link, useNavigate } from "react-router-dom";
import useAuth from "../../hooks/useAuth";

const RoleSelection = () => {
  const [isAdminMode, setIsAdminMode] = useState(false);
  const {isLoggedIn } = useAuth();
  const navigate = useNavigate();
  
  useEffect(() => {
    if (isLoggedIn) {
      navigate("/dashboard");
    }
  }, [isLoggedIn]);

  return (
    <main>
      <div className="main-role-selection-card">
        <Link
          style={{
            textDecoration: "none",
          }}
          {...(isAdminMode ? { to: "/login/admin" } : { to: "/login/visitor" })}
        >
          {isAdminMode ? (
            <FontAwesomeIcon
              icon={faUsersCog}
              size="9x"
              className="user-cog-icon"
            />
          ) : (
            <FontAwesomeIcon
              icon={faAddressCard}
              size="10x"
              className="adress-card-icon"
            />
          )}
          <h2 className="login-header">Logga in</h2>
        </Link>

        <button
          onClick={() => setIsAdminMode(!isAdminMode)}
          className="admin-toggle-button"
        >
          {isAdminMode ? "Logga in som besökare" : "Logga in som admin"}
        </button>
      </div>
    </main>
  );
};

export default RoleSelection;
