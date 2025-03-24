using TrainingManagerAPI.DataAccess;
using TrainingManagerAPI.DTO;
using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.BusinessLogic
{
	public class EmployeeLogic : IEmployeeLogic
	{
		private readonly IEmployeeAccess _employeeDataAccess;
		private readonly IEmployeeTrainingDocumentLogic _employeeTrainingDocumentLogic;

		public EmployeeLogic(EmployeeAccess dataAccess, EmployeeTrainingDocumentLogic ETDLogic)
		{
			_employeeDataAccess = dataAccess;
			_employeeTrainingDocumentLogic = ETDLogic;
		}

		public EmployeeViewDTO getEmployee(int employeeID)
		{
			Employee? employee = _employeeDataAccess.getEmployee(employeeID);

			if (employee == null) { return new EmployeeViewDTO(); }

			List<EmployeeTrainingDocument> etds = [];
			etds = _employeeTrainingDocumentLogic.GetEmployeeTrainingDocuments(employeeID);
			etds = Converter.ToEnum(etds);

			employee.EmployeeTrainingDocuments = etds;

			EmployeeViewDTO employeeViewDTO = Converter.FromEmployee(employee);

			return employeeViewDTO;
		}

		public List<EmployeeViewDTO> GetEmployees()
		{
			List<EmployeeViewDTO> employeeViewDTOs = [];
			List<Employee> employees = _employeeDataAccess.getEmployees();

			foreach (Employee employee in employees)
			{
				if(employee.EmployeeID != null) { 
				employee.EmployeeTrainingDocuments = _employeeTrainingDocumentLogic.GetEmployeeTrainingDocuments((int)employee.EmployeeID);
				}
				EmployeeViewDTO employeeViewDTO = Converter.FromEmployee(employee);
				employeeViewDTOs.Add(employeeViewDTO);
			}

			return employeeViewDTOs;
		}
	}
}
