import './logEntry.css';
import PropTypes from 'prop-types';

const LogEntry = ({ log, index }) => {


    const lightgrey = "#d3d3d3";
    const darkgrey = "#a9a9a9";
    const backgroundColor = index % 2 === 0 ? lightgrey : darkgrey;
    
    
    return (
        <tr style={{ backgroundColor }} className='logPage-table-entry'>
            <td>{log.visitor}</td>
            <td>{log.purpose}</td>
            <td>{log.node}</td>
            <td>{log.date}</td>
        </tr>
    );
};
LogEntry.propTypes = {
    index: PropTypes.number.isRequired,
    log: PropTypes.shape({
        visitor: PropTypes.string.isRequired,
        purpose: PropTypes.string.isRequired,
        node: PropTypes.string.isRequired,
        date: PropTypes.string.isRequired,
    }).isRequired,
};

export default LogEntry;