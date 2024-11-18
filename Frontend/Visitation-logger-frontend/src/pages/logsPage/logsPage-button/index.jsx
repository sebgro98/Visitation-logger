import "./logsPage-button.css";

// eslint-disable-next-line react/prop-types
const LogsPageButton = ({ name, onClick, disabled }) => {
  return (
    <button
      onClick={onClick}
      disabled={disabled}
      className="logsPage-button"
    >
      {name}
    </button>
  );
};

export default LogsPageButton;
