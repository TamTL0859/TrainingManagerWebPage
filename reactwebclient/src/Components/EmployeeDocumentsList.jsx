// src/components/Home.js
// https://localhost:7244/swagger/index.html 
import PropTypes from 'prop-types';
import { useState, useEffect } from "react";

const trainingTypeOptions = ["OPTIONAL", "NOTREQUIRED", "MANDATORY"];
const statusOptions = ["OPTIONAL", "MISSING", "COMPLETED"];


const EmployeeDocumentsList = ({ Employee }) => {
    const [changeableEmployee, setChangeableEmployee] = useState(Employee);
    const [cellClick, setCellClick] = useState(null);

    useEffect(() => {
        setChangeableEmployee(Employee);
    }, [Employee]);


    const handleClick = (index) => {
        setCellClick(index)
    }

    const mouseLeave = () => {
        if (cellClick != null) {
            setCellClick(null);
        }
    }

    const changeToSelectedPointsStatus = (edIndex, selectedValue) => {
        const updatedemployeeTrainingDocuments = changeableEmployee.employeeTrainingDocuments.map((document, index) => {
            return index === edIndex ? { ...document, trainingStatus: selectedValue } : index
        });
        setChangeableEmployee({ ...changeableEmployee, employeeTrainingDocuments: updatedemployeeTrainingDocuments })
    }

    if (Employee == null || Employee.employeeTrainingDocuments == null) { return; }
    return (
        <tbody>
            {Employee.employeeTrainingDocuments.map((ed, edIndex) => (
                <tr key={ed.trainingDocumentID || ""}>
                    <td>{ed.trainingDocumentID || ""}</td>
                    <td>{ed.documentTitle || ""}</td>
                    <td>{ed.trainingType || ""}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.pointsStatus || ""}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {[...Array(ed.pointsGoal / 10 + 1)].map((_, index) => (
                                <button className="dropdown-button" key={index} onClick={() => changeToSelectedPointsStatus(edIndex, index * 10)}>{index * 10}</button>
                            ))}aw
                            </div>
                        )}
                    </td>
                    <td>{ed.pointsGoal || ""}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.trainingRequired || ""}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {trainingTypeOptions.map((text, index) => (
                                <button className="dropdown-button" key={index} onClick="">{text}</button>
                            ))}
                            </div>
                        )}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.trainingStatus || ""}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {statusOptions.map((status, index) => (
                                <button className="dropdown-button" key={index} onClick="">{status}</button>
                            ))}
                            </div>
                        )}</td>
                </tr>
            ))}
        </tbody>
    );
};

EmployeeDocumentsList.propTypes = {
    Employee: PropTypes.shape({
        employeeTrainingDocuments: PropTypes.arrayOf(
            PropTypes.shape({
                trainingDocumentID: PropTypes.string,
                documentTitle: PropTypes.string,
                trainingType: PropTypes.string,
                pointsStatus: PropTypes.string,
                pointsGoal: PropTypes.string,
                trainingRequired: PropTypes.string,
                trainingStatus: PropTypes.string,
            })
        ),
    }).isRequired,
};



export default EmployeeDocumentsList;
