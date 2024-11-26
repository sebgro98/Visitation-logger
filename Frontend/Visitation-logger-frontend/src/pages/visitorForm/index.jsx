import { useEffect, useState } from "react";
import PropTypes from "prop-types";
import Button from "../../components/button";
import Popup from "../../components/popup";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
import "./visitorForm.css";
import {
  validateCompanyName,
  validateFullName,
  validatePassportNumber,
  validateSSN,
  validateTextField,
  validateVisitor,
} from "../../utils/utils";
import { createVisitor, getAllCountries } from "../../services/apiClient";

const VisitorForm = () => {
  const navigate = useNavigate();
  const [countries, setCountries] = useState([]);
  const [formData, setFormData] = useState({
    fullName: "",
    ssn: "",
    countryName: "",
    passportNo: "",
    company: "",
    city: "",
  });
  const [errors, setErrors] = useState({});
  const [showSuccess, setShowSuccess] = useState(false);
  const [successMessage, setSuccessMessage] = useState("");

  const fetchCountries = async () => {
    try {
      const response = await getAllCountries();
      setCountries(response);
    } catch (error) {
      console.error("Error fetching countries:", error);
    }
  };

  useEffect(() => {
    const storedToken = localStorage.getItem("token");
    const decryptedToken = jwt_decode(storedToken);
    const userId = decryptedToken.nameid;
    formData.visitorAccountId = userId;

    fetchCountries();
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

    const { isValid, newErrors } = validateVisitor(formData);
    setErrors(newErrors);

    if (isValid) {
      try {
        // Skicka formulärdata till API eller hantera det på något sätt
        const visitor = await createVisitor(formData);
        console.log("Visitor created:", visitor);

        // Återställ formuläret
        setFormData({
          fullName: "",
          ssn: "",
          countryName: "",
          passportNo: "",
          company: "",
          city: "",
        });

        // Visa framgångsmeddelande
        setSuccessMessage(
          "Besökarens profil har skapats. Var vänlig checka in besökaren."
        );
        setShowSuccess(true);
      } catch (error) {
        console.error("Error submitting form:", error);
      }
    }
  };

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

          <label htmlFor="countryName">Nationalitet</label>
          <select
            id="countryName"
            value={formData.countryName}
            onChange={handleInputChange}
          >
            <option value="" hidden disabled>
              --Välj land--
            </option>
            {countries.map((country) => (
              <option key={country.id} value={country.countryName}>
                {country.countryName}
              </option>
            ))}
          </select>
          <div className="error-container">
            {errors.countryName && (
              <p className="error">{errors.countryName}</p>
            )}
          </div>

          <label htmlFor="passportNo">Passnummer</label>
          <input
            type="text"
            id="passportNo"
            value={formData.passportNo}
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
          <Popup
            message={successMessage}
            onClose={async () => {
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
