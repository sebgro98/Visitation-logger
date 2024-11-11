import { Route, Routes } from "react-router-dom";
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";
import Header from "./components/header";

function App() {
  return (
    <>
      <header>
        <Header isLoggedIn={false} onLogout={() => {}} />
      </header>

      <Routes>
        <Route path="/" element={<RoleSelection />} />
        <Route path="/login/admin" element={<Login isAdminMode={true} />} />
        <Route path="/login/visitor" element={<Login isAdminMode={false} />} />
      </Routes>
    </>
  );
}

export default App;
