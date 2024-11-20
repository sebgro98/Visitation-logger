import { useEffect, useState } from "react";
import "./createAdmin.css";
import Button from "../../components/button";
import {
  validateFullName,
  validatePassword,
  validateUsername,
} from "../../utils/utils";
import {
  createAdminAccount,
  getAllAccountTypes,
  getAllNodes,
} from "../../services/apiClient";
import SuccessPopup from "../../components/successPopup";
import { useNavigate } from "react-router-dom";

const CreateAdmin = () => {
  const navigate = useNavigate();
  const [nodes, setNodes] = useState([]);
  const [accountTypes, setAccountTypes] = useState([]);
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errors, setErrors] = useState({});
  const [showSuccess, setShowSuccess] = useState(false); // För att visa popup
  const [successMessage, setSuccessMessage] = useState("");
  const [account, setAccount] = useState({
    username: "",
    password: "",
    fullName: "",
    accountTypeId: "",
    nodeId: "",
  });

  useEffect(() => {
    const fetchNodes = async () => {
      try {
        const response = await getAllNodes();
        setNodes(response);
      } catch (error) {
        console.error("Error fetching nodes:", error);
      }
    };

    const fetchAccountTypes = async () => {
      try {
        const response = await getAllAccountTypes();
        const filteredResponse = response.filter(
          (type) => type.name !== "Visitor"
        );
        setAccountTypes(filteredResponse);
      } catch (error) {
        console.error("Error fetching account types:", error);
      }
    };

    fetchNodes();
    fetchAccountTypes();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    let valid = true;
    const newErrors = {};

    // Valideringar
    if (!validateUsername(account.username)) {
      newErrors.username = "Användarnamnet måste vara minst 4 tecken";
      valid = false;
    }
    if (!validatePassword(account.password)) {
      newErrors.password =
        "Lösenordet måste vara minst 8 tecken, innehålla en versal, en gemen, en siffra och ett specialtecken";
      valid = false;
    }
    if (account.password !== confirmPassword) {
      newErrors.confirmPassword = "Lösenorden matchar inte";
      valid = false;
    }
    if (!validateFullName(account.fullName)) {
      newErrors.fullName =
        "Fullständigt namn måste vara mellan 4 och 50 tecken";
      valid = false;
    }
    if (!account.accountTypeId) {
      newErrors.accountTypeId = "Vänligen välj en kontotyp.";
      valid = false;
    }
    if (!account.nodeId) {
      newErrors.nodeId = "Vänligen välj en nod.";
      valid = false;
    }

    setErrors(newErrors);

    if (valid) {
      try {
        const response = await createAdminAccount(account);
        console.log("Admin account created:", response);

        const accountTypeName =
          accountTypes.find((type) => type.id === account.accountTypeId)
            ?.name || "";

        const nodeName =
          nodes.find((node) => node.id === account.nodeId)?.nodeName || "";

        const accountInfo = [
          `Användarnamn:\n${account.username}\n`,
          `Fullständigt namn:\n${account.fullName}\n`,
          `Kontotyp:\n${accountTypeName}\n`,
          `Nod:\n${nodeName}`,
        ];

        setSuccessMessage("Kontot har skapats\n\n" + accountInfo.join("\n"));
        setShowSuccess(true);
        // Återställ formuläret
        setAccount({
          username: "",
          password: "",
          fullName: "",
          accountTypeId: "",
          nodeId: "",
        });
        setConfirmPassword("");
      } catch (error) {
        console.error("Error creating admin account:", error);
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
    <main className="create-admin-main">
      <div className="create-admin-container">
        <h1>Skapa adminkonto</h1>
        <form className="create-admin-form" onSubmit={handleSubmit}>
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
            type="password"
            id="password"
            value={account.password}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.password && <p className="error">{errors.password}</p>}
          </div>

          <label htmlFor="confirmPassword">Bekräfta lösenord</label>
          <input
            type="password"
            id="confirmPassword"
            value={confirmPassword}
            onChange={handleConfirmPasswordChange}
          />
          <div className="error-container">
            {errors.confirmPassword && (
              <p className="error">{errors.confirmPassword}</p>
            )}
          </div>

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

          <div className="create-admin-button">
            <Button label={"Skapa konto"} type="submit" />
          </div>
        </form>
        {showSuccess && (
          <SuccessPopup
            message={successMessage}
            onClose={() => {
              setShowSuccess(false);
              setSuccessMessage("");
              navigate("/manage-admins");
            }}
          />
        )}
      </div>
    </main>
  );
};

export default CreateAdmin;
