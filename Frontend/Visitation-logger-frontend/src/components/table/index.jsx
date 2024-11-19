import PropTypes from "prop-types";
import "./table.css";
import { extractValueFromRow } from "../../utils/utils";

const Table = ({ headers, data, onRowClick = () => {} }) => {
  // Mappning mellan engelska nycklar och svenska rubriker
  const headerMapping = {
    username: "Användarnamn",
    name: "Namn",
    node: "Nod",
    startDate: "Start datum",
    endDate: "Slut datum",
    adminName: "Namn",
  };

  return (
    <div className="table-wrapper">
      <table className="table">
        <thead>
          <tr>
            {headers.map((header, index) => (
              <th key={index}>{headerMapping[header]}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data &&
            data.map((visitor, rowIndex) => (
              <tr
                key={rowIndex}
                onClick={() => onRowClick(visitor)}
                className={
                  onRowClick !== Table.defaultProps.onRowClick
                    ? "clickable-row"
                    : ""
                }
              >
                {headers.map((header, colIndex) => (
                  <td key={colIndex}>{extractValueFromRow(visitor, header)}</td>
                ))}
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

Table.propTypes = {
  headers: PropTypes.arrayOf(PropTypes.string).isRequired,
  data: PropTypes.arrayOf(PropTypes.object),
  onRowClick: PropTypes.func, // Lägg till denna prop
};

Table.defaultProps = {
  onRowClick: () => {}, // Tom funktion som standard
};

export default Table;
