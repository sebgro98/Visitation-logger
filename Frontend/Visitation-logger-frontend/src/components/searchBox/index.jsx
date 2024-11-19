import PropTypes from "prop-types";
import "./searchBox.css";

const SearchBox = ({ searchTerm, handleSearchChange }) => {
  return (
    <div className="search-box">
      <input
        type="text"
        placeholder="Sök..."
        value={searchTerm}
        onChange={handleSearchChange}
      />
    </div>
  );
};

SearchBox.propTypes = {
  searchTerm: PropTypes.string.isRequired,
  handleSearchChange: PropTypes.func.isRequired,
};

export default SearchBox;
