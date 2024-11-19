import { useState } from "react";
import "./createAdmin.css";
import Button from "../../components/button";

const CreateAdmin = () => {
  const [account, setAccount] = useState({
    username: "",
    password: "",
    fullName: "",
    accountTypeId: "",
    nodeId: "",
  });

  const [confirmPassword, setConfirmPassword] = useState("");
  const [usernameError, setUsernameError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [confirmPasswordError, setConfirmPasswordError] = useState("");
  const [fullNameError, setFullNameError] = useState("");

  const validateUsername = (username) => {
    return username.length >= 4;
  };

  const validatePassword = (password) => {
    const passwordRegex =
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordRegex.test(password);
  };

  const validateFullName = (fullName) => {
    return (
      fullName.length > 3 &&
      fullName.length <= 50 &&
      /^[a-zA-Z ]+$/.test(fullName)
    );
  };

  const handleSubmit = (e) => {
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

    if (valid) {
      console.log("submit", account);
      // Skicka account till backend här
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
            onChange={(e) =>
              setAccount({ ...account, accountTypeId: e.target.value })
            }
          >
            <option value="1">Admin</option>
            <option value="2">Besökare</option>
          </select>

          <label htmlFor="nodeId">Nod</label>
          <select
            id="nodeId"
            value={account.nodeId}
            onChange={(e) => setAccount({ ...account, nodeId: e.target.value })}
          >
            <option value="1">Node 1</option>
            <option value="2">Node 2</option>
          </select>

          <div className="create-admin-button">
            <Button label={"Skapa konto"} type="submit" />
          </div>
        </form>
      </div>
    </main>
  );
};

export default CreateAdmin;
