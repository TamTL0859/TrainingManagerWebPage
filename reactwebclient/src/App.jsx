import { BrowserRouter, Routes, Route } from "react-router-dom";
import EmployeeListPage from './Pages/EmployeeListPage';
import Layout from './Pages/Layout';
import './App.css';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="documents" element={<EmployeeListPage />} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

// Home Component
const Home = () => {
    return (
        <div style={{ display: "flex"} }>
           HOMEPAGE
            </div>
    );
};


//API_URL = "https://localhost:7244";  // Change this if your API runs on a different port
export default App;
