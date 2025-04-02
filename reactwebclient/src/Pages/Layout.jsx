import { Link, Outlet } from "react-router-dom";
import { useState } from 'react';
import '../css/Layout.css';

const Layout = () => {
    const buttonStyle = {
        display: "inline-block",
        padding: "4px 8px", // Slightly smaller padding
        fontSize: "12px", // Smaller text
        color: "black",
        textDecoration: "none",
        border: "2px solid black",
        borderRadius: "5px",
        backgroundColor: "transparent",
        transition: "all 0.3s ease",
        fontWeight: "bold"
    };

    const [hoverHome, setHomeHover] = useState(false);
    const [hoverDocuments, setHoverDocuments] = useState(false);

    const buttonHoverStyle = {
        ...buttonStyle,
        backgroundColor: "black",  // Background color on hover
        color: "white",  // Text color changes to white on hover
    };

    return (
        <div>
            <header>
                <h3>Training Manager App</h3>
                <nav>
                    <ul style={{ display: "flex", listStyle: "none", padding: 0, gap: "5px" }}>
                        <li><Link to="/" style={hoverHome ? buttonHoverStyle : buttonStyle} onMouseEnter={() => setHomeHover(true)}
                            onMouseLeave={() => setHomeHover(false)}>Home</Link></li>
                        <li><Link to="/documents" style={hoverDocuments ? buttonHoverStyle : buttonStyle} onMouseEnter={() => setHoverDocuments(true)}
                            onMouseLeave={() => setHoverDocuments(false)}>Employee Training Documents</Link></li>
                    </ul>
                </nav>
            </header>

            {/* Content area where the pages will be rendered */}
            <div style={{ display: "flex", justifyContent: "center", alignItems: "center",  minHeight: "100vh" }}>
                <Outlet />
            </div>
        </div>
    );
};

export default Layout;
