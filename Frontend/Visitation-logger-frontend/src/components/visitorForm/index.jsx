import { useState } from "react";
import PropTypes from "prop-types";
import Button from "../button";
import SuccessPopup from "../successPopup";
import { useNavigate } from "react-router-dom";

const VisitorForm = () => {
  const navigate = useNavigate();
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

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setFormData({ ...formData, [id]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validering
    const newErrors = {};
    if (!formData.fullName) newErrors.fullName = "Full Name is required";
    if (!formData.ssn) newErrors.ssn = "SSN/Personnummer is required";
    if (!formData.nationality)
      newErrors.nationality = "Nationality is required";
    if (!formData.passportNumber)
      newErrors.passportNumber = "Passport Number is required";
    if (!formData.company) newErrors.company = "Company is required";
    if (!formData.city) newErrors.city = "City is required";

    setErrors(newErrors);

    if (Object.keys(newErrors).length === 0) {
      try {
        // Skicka formulärdata till API eller hantera det på något sätt
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

  return (
    <main className="visitor-form-main">
      <div className="visitor-form-container">
        <h1>Visitor Form</h1>
        <form className="form" onSubmit={handleSubmit}>
          <label htmlFor="fullName">Full Name</label>
          <input
            type="text"
            id="fullName"
            value={formData.fullName}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.fullName && <p className="error">{errors.fullName}</p>}
          </div>

          <label htmlFor="ssn">SSN/Personnummer</label>
          <input
            type="text"
            id="ssn"
            value={formData.ssn}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.ssn && <p className="error">{errors.ssn}</p>}
          </div>

          <label htmlFor="nationality">Nationality</label>
          <select
            id="nationality"
            value={formData.nationality}
            onChange={handleInputChange}
          >
            <option value="" disabled hidden>
              -- Select Nationality --
            </option>
            <option value="Swedish">Swedish</option>
            <option value="Norwegian">Norwegian</option>
            <option value="Danish">Danish</option>
            <option value="Finnish">Finnish</option>
            {/* Lägg till fler nationaliteter här */}
          </select>
          <div className="error-container">
            {errors.nationality && (
              <p className="error">{errors.nationality}</p>
            )}
          </div>

          <label htmlFor="passportNumber">Passport Number</label>
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

          <label htmlFor="company">Company</label>
          <input
            type="text"
            id="company"
            value={formData.company}
            onChange={handleInputChange}
          />
          <div className="error-container">
            {errors.company && <p className="error">{errors.company}</p>}
          </div>

          <label htmlFor="city">City</label>
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
            <Button label="Submit" type="submit" />
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
