import './logEntry.css';
import PropTypes from 'prop-types';

const LogEntry = ({ log }) => {
    console.log(log);
    
    return (
        <>
            <td>{log.visitor}</td>
            <td>{log.description}</td>
            <td>{log.node}</td>
            <td>{log.date}</td>
        </>
    );
};

// PropTypes validation for ESLint
LogEntry.propTypes = {
    log: PropTypes.shape({
        visitor: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        node: PropTypes.string.isRequired,
        date: PropTypes.string.isRequired
    }).isRequired,
};

export default LogEntry;
