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
