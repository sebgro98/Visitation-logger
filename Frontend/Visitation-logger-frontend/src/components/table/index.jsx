import PropTypes from "prop-types";
import "./table.css";
import { extractValueFromRow } from "../../utils/utils";

const Table = ({ headers, data, onRowClick = () => {} }) => {
  // Mappning mellan engelska nycklar och svenska rubriker
  const headerMapping = {
    username: "Användarnamn",
    visitorName: "Besökare",
    visitorId: "Besökar ID",
    name: "Namn",
    node: "Nod",
    purposeName: "Besöksbeskrivning",
    date: "Datum",
    startDate: "Start datum",
    endDate: "Slut datum",
    checkInTime: "Incheckning",
    checkOutTime: "Utcheckning",
    adminName: "Namn",
    fullName: "Namn",
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
            data.map((acccount, rowIndex) => (
              <tr
                key={rowIndex}
                onClick={() => onRowClick(acccount)}
                className={
                  onRowClick !== Table.defaultProps.onRowClick
                    ? "clickable-row"
                    : ""
                }
              >
                {headers.map((header, colIndex) => (
                  <td key={colIndex}>
                    {extractValueFromRow(acccount, header)}
                  </td>
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
