import PropTypes from "prop-types";
import "./header.css";

const Header = ({ isLoggedIn = false, onLogout = () => {} }) => {
  return (
    <div className="header">
      <h1 className="header-title">Combitech</h1>
      {isLoggedIn && (
        <button className="logout-button" onClick={onLogout}>
          Log Out
        </button>
      )}
    </div>
  );
};

Header.propTypes = {
  isLoggedIn: PropTypes.bool.isRequired,
  onLogout: PropTypes.func.isRequired,
};

export default Header;
