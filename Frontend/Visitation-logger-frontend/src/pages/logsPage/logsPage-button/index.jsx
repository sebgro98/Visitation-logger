import "./logsPage-button.css";

// eslint-disable-next-line react/prop-types
const LogsPageButton = ({ name, onClick }) => {
    return (
        <div className="logsPageButton">
            <button className="logsPage-button" onClick={onClick}>{name}</button>
        </div>
    );
};

export default LogsPageButton;