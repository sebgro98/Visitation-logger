<<<<<<< HEAD
import './login.css'

const Login = () => {
    return (
    <>
        <p>Hi this is login page. Please enter bank details.</p>
    </>
    )
}

export default Login;
=======
import PropTypes from "prop-types";

const Login = ({ isAdminMode }) => {
  return (
    <>
      {isAdminMode ? (
        <div>Admin loggin sida</div>
      ) : (
        <div>Visitor loggin sida</div>
      )}
    </>
  );
};
Login.propTypes = {
  isAdminMode: PropTypes.bool.isRequired,
};

export default Login;
>>>>>>> main
