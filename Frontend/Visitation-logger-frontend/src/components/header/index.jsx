import "./header.css";
import useAuth from "../../hooks/useAuth";
import { Link } from "react-router-dom";

const Header = () => {
  const { onLogout, isLoggedIn } = useAuth();

  return (
    <div className="header">
      <Link className="header-link" to="/dashboard">
        <h1 className="header-title">Combitech</h1>
      </Link>
      {isLoggedIn && (
        <div className="logout-button" onClick={onLogout}>
          Logga ut
        </div>
      )}
    </div>
  );
};

export default Header;
