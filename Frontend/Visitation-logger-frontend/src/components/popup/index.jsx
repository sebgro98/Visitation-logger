import { useEffect } from "react";
import PropTypes from "prop-types";
import "./successPopup.css";

const Popup = ({ message, onClose }) => {
  useEffect(() => {
    const timer = setTimeout(onClose, 3000); // Stänger efter 3 sekunder
    return () => clearTimeout(timer);
  }, [onClose]);

  return (
    // fullscreen overlay
    // popup
    // message

    <div className="success-popup-container">
      <div className="success-popup">
        <p>{message}</p>
      </div>
    </div>
  );
};
Popup.propTypes = {
  message: PropTypes.string.isRequired,
  onClose: PropTypes.func.isRequired,
};

export default Popup;
