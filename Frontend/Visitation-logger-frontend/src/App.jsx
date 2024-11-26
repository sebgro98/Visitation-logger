import { Route, Routes } from "react-router-dom";
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";
import LogsPage from "./pages/logsPage";
import Header from "./components/header";
import { AuthProvider, ProtectedRoute } from "./context/auth";
import Dashboard from "./pages/dashboard";
import AccountManagement from "./pages/accountManagement";
import CreateAdmin from "./pages/createAdmin";
import CreateVisitor from "./pages/createVisitor";
import EditAccount from "./pages/editAccount";
import VisitorForm from "./pages/visitorForm";
import CheckIn from "./pages/checkIn";
import CheckOut from "./pages/checkOut";

function App() {
  return (
    <>
      <AuthProvider>
        <header>
          <Header />
        </header>

        <Routes>
          <Route path="/" element={<RoleSelection />} />
          <Route
            path="/logs"
            element={
              <ProtectedRoute>
                <LogsPage />
              </ProtectedRoute>
            }
          />
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

          <Route
            path="/manage-visitors"
            element={
              <ProtectedRoute>
                <AccountManagement isVisitor={true} />
              </ProtectedRoute>
            }
          />

          <Route
            path="/manage-admins"
            element={
              <ProtectedRoute>
                <AccountManagement isVisitor={false} />
              </ProtectedRoute>
            }
          />

          <Route
            path="/create-admin"
            element={
              <ProtectedRoute>
                <CreateAdmin />
              </ProtectedRoute>
            }
          />

          <Route
            path="/create-visitor"
            element={
              <ProtectedRoute>
                <CreateVisitor />
              </ProtectedRoute>
            }
          />

          <Route
            path="/edit-admin/:id"
            element={
              <ProtectedRoute>
                <EditAccount isEditVisitorMode={false} />
              </ProtectedRoute>
            }
          />

          <Route
            path="/edit-visitor/:id"
            element={
              <ProtectedRoute>
                <EditAccount isEditVisitorMode={true} />
              </ProtectedRoute>
            }
          />

          <Route
            path="/check-in"
            element={
              <ProtectedRoute>
                <CheckIn />
              </ProtectedRoute>
            }
          />

          <Route
            path="/check-out"
            element={
              <ProtectedRoute>
                <CheckOut />
              </ProtectedRoute>
            }
          />
          <Route
            path="/visitor-form"
            element={
              <ProtectedRoute>
                <VisitorForm />
              </ProtectedRoute>
            }
          />
        </Routes>
      </AuthProvider>
    </>
  );
}

export default App;
