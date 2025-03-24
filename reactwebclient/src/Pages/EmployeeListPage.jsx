import { useState, useEffect } from 'react';
import '../css/EmployeeDocumentsTable.css';
import EmployeeAPI from '../ApiAccess/EmployeeAPI.js'
import EmployeeDocumentsList from '../Components/EmployeeDocumentsList.jsx';

const EmployeeTrainingDocumentsPage = () => {
    const [inputValue, setInputValue] = useState("");
    const [loading, setLoading] = useState(false);
    const [Employee, setEmployee] = useState("");


    const handleSearchTest = (event) => {
        event.preventDefault();
        setInputValue(event.target.value);
        console.log(inputValue);

    }

    const APICall = async () => {

        if (loading) return;
        setLoading(true);
        const searchValue = inputValue;
        try {
            const data = await EmployeeAPI.getEmployee(searchValue);
            setEmployee(data);

        } catch (e) {
            console.log("-------------------", e);

        }
        setLoading(false);
        setInputValue("");
    }

    return (
        <div className="parent">
            <h2 className="header">Table page</h2>
            <div className="section">
                <div className="left-section">
                    <form onSubmit={handleSearchTest}>
                        <div className="leftDiv">Employee Search: <input type="text" value={inputValue} onChange={handleSearchTest} />
                            <button onClick={APICall}>Search</button>
                        </div>
                    </form>
                    <div>
                        <h4>Employee Information</h4>
                        <div className="leftDiv">
                            <label>Employee Name: {Employee?.username || ""}</label>
                            <label>Role: {Employee?.role || ""}</label>
                            <label>EmployeeDocuments Amount: {Employee.employeeTrainingDocumentInformation?.documentsCount || ""}</label>
                        </div>
                        <div className="leftDiv">
                            <h4>EmployeeDocuments Information</h4>
                            <label>Total Points Status: {Employee.employeeTrainingDocumentInformation?.totalPointsStatus || ""} </label>
                            <label>Total Points Goal: {Employee.employeeTrainingDocumentInformation?.totalPointsGoal || ""} </label>
                            <label>Total Compliance: {Employee.employeeTrainingDocumentInformation?.pointsDifference || ""} </label>
                        </div>
                    </div>
                </div>
                <div className="right-section">123
                    <table>
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Document Name</th>
                                <th scope="col">Point Status</th>
                                <th scope="col">Point Goal</th>
                                <th scope="col">Type</th>
                                <th scope="col">Required</th>
                                <th scope="col">Status</th>
                            </tr>
                        </thead>
                        <EmployeeDocumentsList Employee={Employee} />
                    </table>
                </div>
            </div>
        </div>
    );
};

export default EmployeeTrainingDocumentsPage;
