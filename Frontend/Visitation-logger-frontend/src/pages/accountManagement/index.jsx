import { useEffect, useState } from "react";
import PropTypes from "prop-types";
import Button from "../../components/button";
import Table from "../../components/table";
import {
  getAdminsByPage,
  getVisitorAccountByPage,
} from "../../services/apiClient";
import "./accountManagement.css";
import SearchBox from "../../components/searchBox";
import { extractValueFromRow } from "../../utils/utils";
import LoadingCircle from "../../components/loadingCircle";
import { useNavigate } from "react-router-dom";

const getHeaders = (isVisitor) => {
  if (isVisitor) {
    return ["username", "name", "node", "startDate", "endDate"];
  } else {
    return ["username", "adminName", "node"];
  }
};

const AccountManagement = ({ isVisitor }) => {
  const headers = getHeaders(isVisitor);
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState("");

  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize] = useState(10);
  const [totalPages, setTotalPages] = useState(0);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        let result;
        if (isVisitor) {
          result = await getVisitorAccountByPage(pageNumber, pageSize);
        } else {
          result = await getAdminsByPage(pageNumber, pageSize);
        }
        setData(result.data);
        setTotalPages(result.totalPages);
      } catch (error) {
        console.error("Error fetching accounts:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [isVisitor, pageNumber, pageSize]);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleRowClick = (visitor) => {
    console.log("Row clicked:", visitor);
    // Här ska vi senare navigera till editera/radera sidan för det valda besökarkontot
  };

  const filteredData = data.filter((item) =>
    headers.some((header) =>
      extractValueFromRow(item, header)
        ?.toString()
        .toLowerCase()
        .includes(searchTerm.toLowerCase())
    )
  );

  const handleNextPage = () => {
    setPageNumber((prev) => prev + 1);
  };

  const handlePrevPage = () => {
    setPageNumber((prev) => prev - 1);
  };

  const isPrevDisabled = pageNumber === 1;

  const isNextDisabled = pageNumber === totalPages;

  if (loading) {
    return <LoadingCircle />; // Använd LoadingCircle-komponenten
  }

  return (
    <main className="main-management">
      <div className="management-container">
        <div className="management-controls">
          <div className="management-button-add">
            <Button
              label={"Lägg till +"}
              onClick={() =>
                navigate(isVisitor ? "/manage-visitors" : "/create-admin")
              }
            />
          </div>
          <SearchBox
            searchTerm={searchTerm}
            handleSearchChange={handleSearchChange}
          />
        </div>
        {filteredData && filteredData.length > 0 ? (
          <Table
            headers={headers}
            data={filteredData}
            onRowClick={handleRowClick}
          />
        ) : (
          <div className="no-visitor-accounts">
            {isNextDisabled ? "Finns inga fler konton" : "Inga konton hittades"}
          </div>
        )}

        <div className="management-buttons-pagination">
          <Button
            label={"Föregående"}
            onClick={handlePrevPage}
            disabled={isPrevDisabled}
          />
          <Button
            label={"Nästa"}
            onClick={handleNextPage}
            disabled={isNextDisabled}
          />
        </div>
      </div>
    </main>
  );
};

AccountManagement.propTypes = {
  isVisitor: PropTypes.bool.isRequired,
};

export default AccountManagement;
