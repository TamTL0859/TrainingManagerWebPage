// src/components/Home.js
// https://localhost:7244/swagger/index.html 
import PropTypes from 'prop-types';
import { useState } from "react";
import EmployeeAPI from '../ApiAccess/EmployeeAPI.js'

const trainingTypeOptions = ["OPTIONAL", "NOTREQUIRED", "MANDATORY"];
const statusOptions = ["OPTIONAL", "MISSING", "COMPLETED"];


const EmployeeDocumentsList = ({ Employee, updateEmployeeData }) => {
    const [cellClick, setCellClick] = useState(null);



    const handleClick = (index) => {
        setCellClick(index)
    }

    const mouseLeave = () => {
        if (cellClick != null) {
            setCellClick(null);
        }
    }

    const changeToSelected = async (type, ed, selectedValue) => {
        const filter = {
            trainingDocumentID: ed.trainingDocumentID,
            statusPoints: null,
            trainingStatus: null,
            trainingRequired: null
        };

        if (type === "pointsStatus") {
            filter.statusPoints = selectedValue;
        } else if (type === "trainingRequired") {
            filter.trainingRequired = selectedValue;
        } else if (type === "trainingStatus") {
            filter.trainingStatus = selectedValue;
            if (selectedValue === "COMPLETED") {
                filter.statusPoints = ed.pointsGoal
            }
        }

        const result = await EmployeeAPI.UpdateEmployeeTrainingDocument(Employee.employeeID, filter);
        if (result) {
            updateEmployeeData(Employee.employeeID)
        }
    }

    if (Employee == null || Employee.employeeTrainingDocuments == null) { return; }
    return (
        <tbody>
            {Employee.employeeTrainingDocuments.map((ed, edIndex) => (
                <tr key={ed.trainingDocumentID || ""}>
                    <td>{ed.trainingDocumentID || ""}</td>
                    <td>{ed.documentTitle || ""}</td>
                    <td>{ed.trainingType || ""}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.pointsStatus || "0"}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {[...Array(ed.pointsGoal / 10 + 1)].map((_, index) => (
                                <button className="dropdown-button" key={index} onClick={() => changeToSelected("pointsStatus", ed, index * 10)}>{index * 10}</button>
                            ))}
                            </div>
                        )}
                    </td>
                    <td>{ed.pointsGoal || ""}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.trainingRequired || ""}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {trainingTypeOptions.map((text, index) => (
                                <button className="dropdown-button" key={index} onClick={() => changeToSelected("trainingRequired", ed, text)}>{text}</button>
                            ))}
                            </div>
                        )}</td>
                    <td className="dropdown" onClick={() => handleClick(edIndex)} onMouseLeave={() => mouseLeave()}>{ed.trainingStatus || ""}
                        {cellClick === edIndex && (
                            <div className="dropdown-content">  {statusOptions.map((status, index) => (
                                <button className="dropdown-button" key={index} onClick={() => changeToSelected("trainingStatus", ed, status)}>{status}</button>
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
        employeeID: PropTypes.string,
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
