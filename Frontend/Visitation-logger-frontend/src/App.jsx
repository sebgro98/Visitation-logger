import { Routes, Route } from 'react-router-dom';
import Login from './pages/login';
import Logs from './pages/logsPage';
import './App.css'

const App = () => {
  return (
    <>
      <Routes>
        <Route path='logs' element={<Logs />}/>
        <Route path='/' element={<Login />}/>
      </Routes>
    </>
  )
}

export default App;
