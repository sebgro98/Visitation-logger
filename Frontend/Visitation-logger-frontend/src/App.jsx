import { Route, Routes } from "react-router-dom";
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";
import Logspage from "./pages/logsPage";
import Header from "./components/header";
import { AuthProvider } from "./context/auth";

function App() {
  return (
    <>
      <header>
        <Header />
      </header>

      <AuthProvider>
        <Routes>
          <Route path="/" element={<RoleSelection />} />
          <Route path="/logs" element={<Logspage/>}/>
          <Route path="/login/admin" element={<Login isAdminMode={true} />} />
          <Route
            path="/login/visitor"
            element={<Login isAdminMode={false} />}
          />
        </Routes>
      </AuthProvider>
    </>
  );
}

export default App;
