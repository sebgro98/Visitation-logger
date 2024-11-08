import { Route, Routes } from "react-router-dom";
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";

function App() {
  return (
    <Routes>
      <Route path="/" element={<RoleSelection />} />
      <Route path="/login/admin" element={<Login isAdminMode={true} />} />
      <Route path="/login/visitor" element={<Login isAdminMode={false} />} />
    </Routes>
  );
}

export default App;
