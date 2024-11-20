import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import PropTypes from "prop-types";

const DashboardAction = ({ to, icons, title, info }) => {
  return (
    <div className="dashboard-action">
      <Link to={to}>
        <div className="icon-container">
          {icons.map((icon, index) => (
            <FontAwesomeIcon
              key={index}
              icon={icon}
              className="dashboard-icon"
            />
          ))}
        </div>
      </Link>
      <div className="dashboard-action-header">
        <h2 className="dashboard-action-header-title">{title}</h2>
        <p className="dashboard-action-header-info">{info}</p>
      </div>
    </div>
  );
};

DashboardAction.propTypes = {
  to: PropTypes.string.isRequired,
  onClick: PropTypes.func,
  icons: PropTypes.arrayOf(PropTypes.object).isRequired,
  title: PropTypes.string.isRequired,
  info: PropTypes.string,
};

export default DashboardAction;
