import { useEffect, useState } from "react";
import PropTypes from "prop-types";
import Button from "../../components/button";
import Table from "../../components/table";
import {
  getAllAdminAccounts,
  getAllVisitorAccounts,
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
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        let result;
        if (isVisitor) {
          result = await getAllVisitorAccounts();
        } else {
          result = await getAllAdminAccounts();
        }
        setData(result);
      } catch (error) {
        console.error("Error fetching accounts:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [isVisitor]);

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
          <div className="no-visitor-accounts">Inga besökarkonton hittades</div>
        )}

        <div className="management-buttons-pagination">
          <Button
            label={"Föregående"}
            onClick={() => {
              console.log("Klickat på föregående");
            }}
          />
          <Button
            label={"Nästa"}
            onClick={() => {
              console.log("Klickat på nästa");
            }}
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
