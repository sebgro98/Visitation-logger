import "./button.css";

// eslint-disable-next-line react/prop-types
const Button = ({ label, onClick, disabled = false }) => {
  return (
    <button onClick={onClick} disabled={disabled} className="button">
      {label}
    </button>
  );
};

export default Button;
