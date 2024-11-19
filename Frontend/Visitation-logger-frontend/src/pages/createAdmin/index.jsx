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

const CreateAdmin = () => {
  const [nodes, setNodes] = useState([]);
  const [accountTypes, setAccountTypes] = useState([]);
  const [account, setAccount] = useState({
    username: "",
    password: "",
    fullName: "",
    accountTypeId: "",
    nodeId: "",
  });
  console.log(account);
  console.log(accountTypes[0]?.id);

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

  const [confirmPassword, setConfirmPassword] = useState("");
  const [usernameError, setUsernameError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [confirmPasswordError, setConfirmPasswordError] = useState("");
  const [fullNameError, setFullNameError] = useState("");
  const [accountTypeError, setAccountTypeError] = useState("");
  const [nodeError, setNodeError] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    let valid = true;

    if (!validateUsername(account.username)) {
      setUsernameError("Användarnamnet måste vara minst 4 tecken");
      valid = false;
    } else {
      setUsernameError("");
    }

    if (!validatePassword(account.password)) {
      setPasswordError(
        "Lösenordet måste vara minst 8 tecken, innehålla en versal, en gemen, en siffra och ett specialtecken"
      );
      valid = false;
    } else {
      setPasswordError("");
    }

    if (account.password !== confirmPassword) {
      setConfirmPasswordError("Lösenorden matchar inte");
      valid = false;
    } else {
      setConfirmPasswordError("");
    }

    if (!validateFullName(account.fullName)) {
      setFullNameError("Fullständigt namn måste vara mellan 4 och 50 tecken");
      valid = false;
    } else {
      setFullNameError("");
    }

    if (!account.accountTypeId) {
      setAccountTypeError("Vänligen välj en kontotyp.");
      valid = false;
    } else {
      setAccountTypeError("");
    }

    if (!account.nodeId) {
      setNodeError("Vänligen välj en nod.");
      valid = false;
    } else {
      setNodeError("");
    }

    if (valid) {
      console.log("submit", account);
      try {
        const response = await createAdminAccount(account);
        console.log("Admin account created:", response);
      } catch (error) {
        console.error("Error creating admin account:", error);
      }
    }
  };

  console.log(account.accountTypeId);

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
            onChange={(e) => {
              if (usernameError && validateUsername(e.target.value)) {
                setUsernameError("");
              }
              setAccount({ ...account, username: e.target.value });
            }}
          />
          <div className="error-container">
            {usernameError && <p className="error">{usernameError}</p>}
          </div>

          <label htmlFor="password">Lösenord</label>
          <input
            type="password"
            id="password"
            value={account.password}
            onChange={(e) => {
              if (passwordError && validatePassword(e.target.value)) {
                setPasswordError("");
              }
              setAccount({ ...account, password: e.target.value });
            }}
          />
          <div className="error-container">
            {passwordError && <p className="error">{passwordError}</p>}
          </div>

          <label htmlFor="confirmPassword">Bekräfta lösenord</label>
          <input
            type="password"
            id="confirmPassword"
            value={confirmPassword}
            onChange={(e) => {
              if (
                e.target.value.length >= account.password.length &&
                e.target.value !== account.password
              ) {
                setConfirmPasswordError("Lösenorden matchar inte");
              } else {
                setConfirmPasswordError("");
              }
              setConfirmPassword(e.target.value);
            }}
          />
          <div className="error-container">
            {confirmPasswordError && (
              <p className="error">{confirmPasswordError}</p>
            )}
          </div>

          <label htmlFor="fullName">Fullständigt namn</label>
          <input
            type="text"
            id="fullName"
            value={account.fullName}
            onChange={(e) => {
              if (fullNameError && validateFullName(e.target.value)) {
                setFullNameError("");
              }
              setAccount({ ...account, fullName: e.target.value });
            }}
          />
          <div className="error-container">
            {fullNameError && <p className="error">{fullNameError}</p>}
          </div>

          <label htmlFor="accountTypeId">Kontotyp</label>
          <select
            id="accountTypeId"
            value={account.accountTypeId}
            onChange={(e) => {
              if (accountTypeError) {
                setAccountTypeError("");
              }

              setAccount({ ...account, accountTypeId: e.target.value });
            }}
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
            {accountTypeError && <p className="error">{accountTypeError}</p>}
          </div>

          <label htmlFor="nodeId">Nod</label>
          <select
            id="nodeId"
            value={account.nodeId}
            onChange={(e) => {
              if (nodeError) {
                setNodeError("");
              }
              setAccount({ ...account, nodeId: e.target.value });
            }}
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
            {nodeError && <p className="error">{nodeError}</p>}
          </div>

          <div className="create-admin-button">
            <Button label={"Skapa konto"} type="submit" />
          </div>
        </form>
      </div>
    </main>
  );
};

export default CreateAdmin;
