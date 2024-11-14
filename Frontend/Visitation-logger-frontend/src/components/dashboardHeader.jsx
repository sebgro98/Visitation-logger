import PropTypes from "prop-types";

const DashboardHeader = ({ title, info }) => {
  return (
    <div className="dashboard-header">
      <h1 className="dashboard-header-title">{title}</h1>
      <p className="dashboard-header-info">{info}</p>
    </div>
  );
};

DashboardHeader.propTypes = {
  title: PropTypes.string.isRequired,
  info: PropTypes.string.isRequired,
};

export default DashboardHeader;
