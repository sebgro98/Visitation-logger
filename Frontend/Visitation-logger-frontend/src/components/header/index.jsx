import "./header.css";
import useAuth from "../../hooks/useAuth";

const Header = () => {
  const { onLogout, isLoggedIn } = useAuth();
  console.log(isLoggedIn);

  return (
    <div className="header">
      <h1 className="header-title">Combitech</h1>
      {isLoggedIn && (
        <div className="logout-button" onClick={onLogout}>
          Logga ut
        </div>
      )}
    </div>
  );
};

export default Header;
