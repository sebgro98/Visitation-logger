// utils.js
export const formatDate = (date) => {
  if (!date) return "";
  const d = new Date(date);
  const year = d.getFullYear();
  const month = String(d.getMonth() + 1).padStart(2, "0"); // Lägg till 1 eftersom månaderna är 0-indexerade
  const day = String(d.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
};

// Funktion för att extrahera värden från nested objekt
export const extractValueFromRow = (row, header) => {
  switch (header) {
    case "node":
      return row.node?.nodeName || "";
    case "name":
      return row.visitor?.fullName || "";
    case "startDate":
      return formatDate(row.startDate);
    case "endDate":
      return formatDate(row.endDate);
    case "checkInTime":
      return row.checkInTime ? new Date(row.checkInTime).toLocaleString() : "";
    case "checkOutTime":
      return row.checkOutTime
        ? new Date(row.checkOutTime).toLocaleString()
        : "";
    default:
      return row[header] || "";
  }
};

// Funktion för att validera användarnamn
export const validateUsername = (username) => {
  const usernameRegex = /^[a-zA-Z0-9]{4,20}$/;
  return usernameRegex.test(username);
};

// Funktion för att validera lösenord
export const validatePassword = (password) => {
  const passwordRegex =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
  return passwordRegex.test(password);
};

// Funktion för att validera fullständigt namn
export const validateFullName = (fullName) => {
  const nameRegex = /^[a-zA-Z\s]{4,50}$/;
  return nameRegex.test(fullName);
};

// Funktion för att validera SSN/Personnummer
export const validateSSN = (ssn) => {
  const ssnRegex = /^\d{8}-\d{4}$/;
  return ssnRegex.test(ssn);
};

// Funktion för att validera passnummer
export const validatePassportNumber = (passportNumber) => {
  const passportRegex = /^[A-Z0-9]{8,9}$/;
  return passportRegex.test(passportNumber);
};

// Funktion för att validera företagsnamn
export const validateCompanyName = (companyName) => {
  const companyRegex = /^[a-zA-Z0-9@&\-_ ]{1,50}$/;
  return companyRegex.test(companyName);
};

// Funktion för att validera stad
export const validateTextField = (city) => {
  const cityRegex = /^[a-zA-Z\s]{1,50}$/;
  return cityRegex.test(city);
};

// Funktion för att trimma onödiga mellanslag från ett objekt
export const trimObjectStrings = (obj) => {
  const trimmedObj = { ...obj };
  Object.keys(trimmedObj).forEach((key) => {
    if (typeof trimmedObj[key] === "string") {
      trimmedObj[key] = trimmedObj[key].trim();
    }
  });
  return trimmedObj;
};

export const prepareAdminAccount = (account) => {
  const trimmedAccount = trimObjectStrings(account);

  return trimmedAccount;
};

// Funktion för att förbereda besökarkonto för att skicka till backend
export const prepareVisitorAccount = (account, accountTypes) => {
  const trimmedAccount = trimObjectStrings(account);
  // Konvertera datum till UTC när du skickar dem till backend
  const startDateUTC = new Date(trimmedAccount.startDate).toISOString();
  // Justera endDate till 23:59:59
  const endDate = new Date(trimmedAccount.endDate);
  endDate.setHours(23, 59, 59, 999);
  const endDateUTC = endDate.toISOString();

  const updatedAccount = {
    ...trimmedAccount,
    startDate: startDateUTC,
    endDate: endDateUTC,
  };

  updatedAccount.accountTypeId = accountTypes.find(
    (type) => type.name === "Visitor"
  )?.id;

  return updatedAccount;
};

// Används för att validera kontouppgifter vid skapande av konto
export const validateAccount = (
  account,
  confirmPassword,
  accountType,
  isEditMode
) => {
  const newErrors = {};
  let valid = true;

  if (!validateUsername(account.username)) {
    newErrors.username =
      "Användarnamnet måste vara minst 4 och max 20 tecken får endast innehålla bokstäver och siffror, inga mellanslag.";
    valid = false;
  }
  if (
    (isEditMode && account.password && !validatePassword(account.password)) ||
    (!isEditMode && !validatePassword(account.password))
  ) {
    newErrors.password =
      "Lösenordet måste vara minst 8 tecken, innehålla en versal, en gemen, en siffra och ett specialtecken";
    valid = false;
  }
  if (!isEditMode && account.password !== confirmPassword) {
    newErrors.confirmPassword = "Lösenorden matchar inte";
    valid = false;
  }
  if (accountType === "visitor") {
    if (!account.startDate) {
      newErrors.startDate = "Vänligen välj ett startdatum.";
      valid = false;
    } else {
      if (
        !isEditMode &&
        account.startDate < new Date().toISOString().split("T")[0]
      ) {
        newErrors.startDate =
          "Startdatumet kan inte vara tidigare än dagens datum.";
        valid = false;
      }
    }

    if (!account.endDate) {
      newErrors.endDate = "Vänligen välj ett slutdatum.";
      valid = false;
    } else {
      if (account.endDate < account.startDate) {
        newErrors.endDate =
          "Slutdatumet kan inte vara tidigare än startdatumet."; // ta bort fixa
        valid = false;
      } else if (account.endDate < new Date().toISOString().split("T")[0]) {
        newErrors.endDate =
          "Slutdatumet kan inte vara tidigare än dagens datum.";
        valid = false;
      }
    }
    if (!account.purposeTypeId) {
      newErrors.purposeTypeId = "Vänligen ange syftet med kontot.";
      valid = false;
    }
  } else {
    if (!validateFullName(account.fullName)) {
      newErrors.fullName =
        "Fullständigt namn måste vara mellan 4 och 50 tecken och får endast innehålla bokstäver och mellanslag";
      valid = false;
    }
    if (!account.accountTypeId) {
      newErrors.accountTypeId = "Vänligen välj en kontotyp.";
      valid = false;
    }
  }
  if (!account.nodeId) {
    newErrors.nodeId = "Vänligen välj en nod.";
    valid = false;
  }

  return { valid, newErrors };
};

export const validateVisitor = (formData) => {
  const newErrors = {};
  let isValid = true;

  if (!validateFullName(formData.fullName)) {
    newErrors.fullName =
      "Användarnamnet måste vara minst 4 och max 20 tecken får endast innehålla bokstäver och siffror, inga mellanslag.";
    isValid = false;
  }
  if (!validateSSN(formData.ssn)) {
    newErrors.ssn = "Personnumret måste vara i formatet ÅÅÅÅMMDD-XXXX";
    isValid = false;
  }
  if (!formData.countryName) {
    newErrors.countryName =
      "Var god välj ett land från listan. Om ditt land inte finns med, vänligen kontakta support.";
    isValid = false;
  }
  if (!validatePassportNumber(formData.passportNo)) {
    newErrors.passportNumber =
      "Passnummer måste vara 8-9 tecken långt och får endast innehålla bokstäver och siffror";
    isValid = false;
  }
  if (!validateCompanyName(formData.company)) {
    newErrors.company =
      "Företagsnamnet får endast innehålla bokstäver och siffror och vara max 50 tecken långt";
    isValid = false;
  }
  if (!validateTextField(formData.city)) {
    newErrors.city =
      "Stad får endast innehålla bokstäver och vara max 50 tecken långt";
    isValid = false;
  }

  return { isValid, newErrors };
};
