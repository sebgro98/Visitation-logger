import { useCallback, useEffect, useState } from "react";
import PropTypes from "prop-types";
import "./handleAccount.css";
import Button from "../button";
import {
  generateAccountInfo,
  prepareAdminAccount,
  prepareVisitorAccount,
  validateAccount,
  validateFullName,
  validatePassword,
  validateUsername,
} from "../../utils/utils";
import SuccessPopup from "../successPopup";
import { useNavigate, useParams } from "react-router-dom";
import {
  getAllAccountTypes,
  getAllNodes,
  getAllPurposeTypes,
} from "../../services/apiClient";

const HandleAccount = ({
  accountType,
  handleAccountAction,
  fields,
  isEditMode = false,
}) => {
  const navigate = useNavigate();
  const { id = "" } = useParams();
  const [nodes, setNodes] = useState([]);
  const [accountTypes, setAccountTypes] = useState([]);
  const [purposeTypes, setPurposeTypes] = useState([]);
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errors, setErrors] = useState({});
  const [showSuccess, setShowSuccess] = useState(false); // För att visa popup
  const [successMessage, setSuccessMessage] = useState("");
  const [account, setAccount] = useState({});

  const fetchNodes = useCallback(async () => {
    try {
      const response = await getAllNodes();
      setNodes(response);
    } catch (error) {
      console.error("Error fetching nodes:", error);
    }
  }, []);

  const fetchAccountTypes = useCallback(async () => {
    try {
      const response = await getAllAccountTypes();
      if (accountType !== "visitor") {
        const filteredResponse = response.filter(
          (type) => type.name !== "Visitor"
        );
        setAccountTypes(filteredResponse);
      } else {
        setAccountTypes(response);
      }
    } catch (error) {
      console.error("Error fetching account types:", error);
    }
  }, [accountType]);

  const fetchPurposeTypes = useCallback(async () => {
    try {
      const response = await getAllPurposeTypes();
      setPurposeTypes(response);
    } catch (error) {
      console.error("Error fetching purpose types:", error);
    }
  }, []);

  useEffect(() => {
    if (isEditMode) {
      // eslint-disable-next-line no-unused-vars
      const { password, ...rest } = fields;
      setAccount(rest);
    } else {
      setAccount(fields);
    }
    fetchNodes();
    fetchAccountTypes();
    if (accountType === "visitor") {
      fetchPurposeTypes();
    }
  }, [fetchNodes, fetchAccountTypes, fetchPurposeTypes, accountType]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const { valid, newErrors } = validateAccount(
      account,
      confirmPassword,
      accountType,
      isEditMode
    );
    setErrors(newErrors);

    if (valid) {
      let accountData;

      if (accountType === "visitor") {
        accountData = prepareVisitorAccount(account, accountTypes);
      } else {
        accountData = prepareAdminAccount(account);
      }

      try {
        if (isEditMode) {
          await handleAccountAction(id, accountData);
        } else {
          await handleAccountAction(accountData);
        }

        const accountInfo = generateAccountInfo(
          account,
          accountType,
          nodes,
          accountTypes,
          purposeTypes
        );

        setSuccessMessage("Kontot har skapats\n\n" + accountInfo.join("\n"));
        setShowSuccess(true);

        // Återställ formuläret
        setAccount({});
        setConfirmPassword("");
      } catch (error) {
        console.error(`Error creating ${accountType} account:`, error);
      }
    }
  };

  const handleInputChange = (e) => {
    const { id, value } = e.target;

    // Rensa felmeddelande om fältet validerar korrekt
    if (errors[id]) {
      let isValid = true;
      switch (id) {
        case "username":
          isValid = validateUsername(value);
          break;
        case "password":
          isValid = validatePassword(value);
          break;
        case "fullName":
          isValid = validateFullName(value);
          break;
        case "startDate":
        case "endDate":
        case "purposeTypeId":
        case "accountTypeId":
        case "nodeId":
          isValid = value !== "";
          break;
        default:
          break;
      }
      if (isValid) {
        setErrors({ ...errors, [id]: "" });
      }
    }

    setAccount({ ...account, [id]: value });
  };

  const handleConfirmPasswordChange = (e) => {
    const value = e.target.value;
    setConfirmPassword(value);

    if (value.length >= account.password.length && value !== account.password) {
      setErrors({
        ...errors,
        confirmPassword: "Lösenorden matchar inte",
      });
    } else {
      setErrors({
        ...errors,
        confirmPassword: "",
      });
    }
  };

  return (
    <main className="create-account-main">
      <div className="create-account-container">
        <h1>
          {accountType === "visitor"
            ? isEditMode
              ? "Redigera besökare"
              : "Skapa besökare"
            : isEditMode
            ? "Redigera administratör"
            : "Skapa administratör"}
        </h1>
        <form className="create-account-form" onSubmit={handleSubmit}>
          <label htmlFor="username">Användarnamn</label>
          <input
            type="text"
            id="username"
            value={account.username}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.username && <p className="error">{errors.username}</p>}
          </div>

          <label htmlFor="password">Lösenord</label>
          <input
            type="text"
            id="password"
            value={account.password}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.password && <p className="error">{errors.password}</p>}
          </div>

          <label htmlFor="confirmPassword">Bekräfta lösenord</label>
          <input
            type="text"
            id="confirmPassword"
            value={confirmPassword}
            onChange={handleConfirmPasswordChange}
          />
          <div className="error-container">
            {errors.confirmPassword && (
              <p className="error">{errors.confirmPassword}</p>
            )}
          </div>

          {accountType === "visitor" ? (
            <>
              <label htmlFor="startDate">Startdatum</label>
              <input
                type="date"
                id="startDate"
                value={account.startDate}
                onChange={handleInputChange}
              />
              <div className="error-container">
                {errors.startDate && (
                  <p className="error">{errors.startDate}</p>
                )}
              </div>

              <label htmlFor="endDate">Slutdatum</label>
              <input
                type="date"
                id="endDate"
                value={account.endDate}
                onChange={handleInputChange}
              />
              <div className="error-container">
                {errors.endDate && <p className="error">{errors.endDate}</p>}
              </div>

              <label htmlFor="purposeTypeId">Syfte</label>
              <select
                id="purposeTypeId"
                value={account.purposeTypeId}
                onChange={handleInputChange}
              >
                <option value="" disabled hidden>
                  -- Välj syfte --
                </option>
                {purposeTypes.map((purpose) => (
                  <option key={purpose.id} value={purpose.id}>
                    {purpose.name}
                  </option>
                ))}
              </select>
              <div className="error-container">
                {errors.purposeTypeId && (
                  <p className="error">{errors.purposeTypeId}</p>
                )}
              </div>
            </>
          ) : (
            <>
              <label htmlFor="fullName">Fullständigt namn</label>
              <input
                type="text"
                id="fullName"
                value={account.fullName}
                onChange={handleInputChange}
              />
              <div className="error-container">
                {errors.fullName && <p className="error">{errors.fullName}</p>}
              </div>
              <label htmlFor="accountTypeId">Kontotyp</label>
              <select
                id="accountTypeId"
                value={account.accountTypeId}
                onChange={handleInputChange}
              >
                <option value="" disabled hidden>
                  -- Välj kontotyp --
                </option>
                {accountTypes.map((accountType) => (
                  <option key={accountType.id} value={accountType.id}>
                    {accountType.name}
                  </option>
                ))}
              </select>
              <div className="error-container">
                {errors.accountTypeId && (
                  <p className="error">{errors.accountTypeId}</p>
                )}
              </div>
            </>
          )}

          <label htmlFor="nodeId">Nod</label>
          <select
            id="nodeId"
            value={account.nodeId}
            onChange={handleInputChange}
          >
            <option value="" disabled hidden>
              -- Välj nod --
            </option>
            {nodes.map((node) => (
              <option key={node.id} value={node.id}>
                {node.nodeName}
              </option>
            ))}
          </select>
          <div className="error-container">
            {errors.nodeId && <p className="error">{errors.nodeId}</p>}
          </div>

          <div className="create-account-button">
            <Button
              label={isEditMode ? "Updatera konto" : "Skapa konto"}
              type="submit"
            />
          </div>
        </form>
        {showSuccess && (
          <SuccessPopup
            message={successMessage}
            onClose={() => {
              setShowSuccess(false);
              setSuccessMessage("");
              navigate(
                accountType === "visitor"
                  ? "/manage-visitors"
                  : "/manage-admins"
              );
            }}
          />
        )}
      </div>
    </main>
  );
};
HandleAccount.propTypes = {
  accountType: PropTypes.string.isRequired,
  handleAccountAction: PropTypes.func.isRequired,
  fields: PropTypes.object.isRequired,
  isEditMode: PropTypes.bool,
};

export default HandleAccount;
