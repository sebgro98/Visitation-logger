import { Route, Routes } from "react-router-dom";
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";
import Logspage from "./pages/logsPage";
import Header from "./components/header";
import { AuthProvider, ProtectedRoute } from "./context/auth";
import Dashboard from "./pages/dashboard";

function App() {
  return (
    <>
      <AuthProvider>
        <header>
          <Header />
        </header>

        <Routes>
          <Route path="/" element={<RoleSelection />} />
          <Route path="/logs" element={<Logspage/>}/>
          <Route path="/login/admin" element={<Login isAdminMode={true} />} />
          <Route
            path="/login/visitor"
            element={<Login isAdminMode={false} />}
          />

          <Route
            path="/dashboard"
            element={
              <ProtectedRoute>
                <Dashboard />
              </ProtectedRoute>
            }
          />
        </Routes>
      </AuthProvider>
    </>
  );
}

export default App;
