import { Route, Routes } from "react-router-dom";
import { createContext } from 'react';
import "./App.css";
import RoleSelection from "./pages/roleSelection";
import Login from "./pages/login";
import Logspage from "./pages/logsPage";
import Header from "./components/header";


export const LogsContext = createContext();
function App() {
  return (
    <>
      <header>
        <Header />
      </header>

      <Routes>
        <Route path="/" element={<RoleSelection />} />
        <Route path="/logs" element={<Logspage/>}/>
        <Route path="/login/admin" element={<Login isAdminMode={true} />} />
        <Route path="/login/visitor" element={<Login isAdminMode={false} />} />
      </Routes>
    </>
  );
}

export default App;
