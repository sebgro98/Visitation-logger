import './logEntry.css';
import PropTypes from 'prop-types';

const LogEntry = ({ log }) => {
    console.log(log);
    
    return (
        <tr>

            <td>{log.visitor}</td>
            <td>{log.description}</td>
            <td>{log.node}</td>
            <td>{log.date}</td>
        </tr>
    );
};
LogEntry.propTypes = {
    log: PropTypes.shape({
        visitor: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        node: PropTypes.string.isRequired,
        date: PropTypes.string.isRequired,
    }).isRequired,
};

export default LogEntry;