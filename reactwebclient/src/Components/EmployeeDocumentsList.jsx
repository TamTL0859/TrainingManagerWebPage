// src/components/Home.js
// https://localhost:7244/swagger/index.html 
import PropTypes from 'prop-types';

const EmployeeDocumentsList = ({ Employee }) => {
    if (Employee == null || Employee.employeeTrainingDocuments == null) { return; }
     return (
        <tbody>
            {Employee.employeeTrainingDocuments.map((ed) => (
                <tr key={ed.trainingDocumentID || ""}>
                    <td>{ed.trainingDocumentID || ""}</td>
                    <td>{ed.documentTitle || ""}</td>
                    <td>{ed.pointsStatus || ""}</td>
                    <td>{ed.pointsGoal || ""}</td>
                    <td>{ed.trainingType || ""}</td>
                    <td>{ed.trainingRequired || ""}</td>
                    <td>{ed.trainingStatus || ""}</td>
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
                pointsStatus: PropTypes.string,
                pointsGoal: PropTypes.string,
                trainingType: PropTypes.string,
                trainingRequired: PropTypes.string,
                trainingStatus: PropTypes.string,
            })
        ),
    }).isRequired,
};



export default EmployeeDocumentsList;
