import { useEffect, useState } from "react";
import PropTypes from "prop-types";
import Button from "../button";
import SuccessPopup from "../successPopup";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
import "./visitorForm.css";
import {
  validateCompanyName,
  validateFullName,
  validatePassportNumber,
  validateSSN,
  validateTextField,
} from "../../utils/utils";
import { createVisitor } from "../../services/apiClient";

const VisitorForm = () => {
  const navigate = useNavigate();
  const [hasVisitorId, setHasVisitorId] = useState(false);
  const [userId, setUserId] = useState("");
  const [formData, setFormData] = useState({
    fullName: "",
    ssn: "",
    nationality: "",
    passportNumber: "",
    company: "",
    city: "",
  });
  const [errors, setErrors] = useState({});
  const [showSuccess, setShowSuccess] = useState(false);
  const [successMessage, setSuccessMessage] = useState("");

  useEffect(() => {
    const storedToken = localStorage.getItem("token");
    const decryptedToken = jwt_decode(storedToken);
    const hasVisitorId = decryptedToken.HasVisitorId === "True";
    setHasVisitorId(hasVisitorId);

    if (hasVisitorId) {
      setUserId(decryptedToken.userId);
    }
  }, []);

  const handleInputChange = (e) => {
    const { id, value } = e.target;

    // Rensa felmeddelande om fältet validerar korrekt
    if (errors[id]) {
      let isValid = true;
      switch (id) {
        case "fullName":
          isValid = validateFullName(value);
          break;
        case "ssn":
          isValid = validateSSN(value);
          break;
        case "nationality":
          isValid = validateTextField(value);
          break;
        case "passportNumber":
          isValid = validatePassportNumber(value);
          break;
        case "company":
          isValid = validateCompanyName(value);
          break;
        case "city":
          isValid = validateTextField(value);
          break;
        default:
          break;
      }
      if (isValid) {
        setErrors({ ...errors, [id]: null });
      }
    }
    setFormData({ ...formData, [id]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validering
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
    if (!validateTextField(formData.nationality)) {
      newErrors.nationality =
        "Nationalitet får endast innehålla bokstäver och vara max 50 tecken långt";
      isValid = false;
    }
    if (!validatePassportNumber(formData.passportNumber)) {
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

    setErrors(newErrors);

    if (isValid) {
      try {
        // Skicka formulärdata till API eller hantera det på något sätt
        const visitor = await createVisitor(formData);
        console.log("Visitor created:", visitor);
        setSuccessMessage("Formuläret har skickats");
        setShowSuccess(true);

        // Återställ formuläret
        setFormData({
          fullName: "",
          ssn: "",
          nationality: "",
          passportNumber: "",
          company: "",
          city: "",
        });
      } catch (error) {
        console.error("Error submitting form:", error);
      }
    }
  };

  if (hasVisitorId) {
    return (
      <div className="visitor-form-container">
        <h1>Visitor Form</h1>
        <p>Welcome</p>
      </div>
    );
  }

  return (
    <main className="visitor-form-main">
      <div className="visitor-form-container">
        <h1>Besöks Formulär</h1>
        <p style={{ marginTop: "0" }}>Vänligen fyll i formuläret nedan</p>
        <form className="form" onSubmit={handleSubmit}>
          <label htmlFor="fullName">Fullständigtnamn</label>
          <input
            type="text"
            id="fullName"
            value={formData.fullName}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.fullName && <p className="error">{errors.fullName}</p>}
          </div>

          <label htmlFor="ssn">Personnummer</label>
          <input
            type="text"
            id="ssn"
            value={formData.ssn}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.ssn && <p className="error">{errors.ssn}</p>}
          </div>

          <label htmlFor="nationality">Nationalitet</label>
          <input
            type="text"
            id="nationality"
            value={formData.national}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.nationality && (
              <p className="error">{errors.nationality}</p>
            )}
          </div>

          <label htmlFor="passportNumber">Passnummer</label>
          <input
            type="text"
            id="passportNumber"
            value={formData.passportNumber}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.passportNumber && (
              <p className="error">{errors.passportNumber}</p>
            )}
          </div>

          <label htmlFor="company">Företag</label>
          <input
            type="text"
            id="company"
            value={formData.company}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.company && <p className="error">{errors.company}</p>}
          </div>

          <label htmlFor="city">Stad</label>
          <input
            type="text"
            id="city"
            value={formData.city}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.city && <p className="error">{errors.city}</p>}
          </div>

          <div className="visitor-form-button">
            <Button label="Skicka" type="submit" />
          </div>
        </form>
        {showSuccess && (
          <SuccessPopup
            message={successMessage}
            onClose={() => {
              setShowSuccess(false);
              setSuccessMessage("");
              navigate("/dashboard");
            }}
          />
        )}
      </div>
    </main>
  );
};

VisitorForm.propTypes = {
  handleAccountAction: PropTypes.func,
};

export default VisitorForm;
