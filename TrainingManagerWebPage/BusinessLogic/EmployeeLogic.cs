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

		public async Task<EmployeeViewDTO> GetEmployee(int employeeID)
		{
			Employee? employee = await _employeeDataAccess.getEmployee(employeeID);

			if (employee == null) { return new EmployeeViewDTO(); }

			List<EmployeeTrainingDocument> etds = [];
			etds = await _employeeTrainingDocumentLogic.GetEmployeeTrainingDocuments(employeeID);
			etds = Converter.ToEnum(etds);

			employee.EmployeeTrainingDocuments = etds;

			EmployeeViewDTO employeeViewDTO = Converter.FromEmployee(employee);

			return employeeViewDTO;
		}

		public async Task<List<EmployeeViewDTO>> GetEmployees()
		{
			List<EmployeeViewDTO> employeeViewDTOs = [];
			List<Employee> employees = await _employeeDataAccess.getEmployees();

			foreach (Employee employee in employees)
			{
				if(employee.EmployeeID != null) { 
				employee.EmployeeTrainingDocuments = await _employeeTrainingDocumentLogic.GetEmployeeTrainingDocuments((int)employee.EmployeeID);
				}
				EmployeeViewDTO employeeViewDTO = Converter.FromEmployee(employee);
				employeeViewDTOs.Add(employeeViewDTO);
			}

			return employeeViewDTOs;
		}

		public async Task<bool> UpdateEmployeeTrainingDocumentBasedOnFilter(int id, EmployeeTrainingDocumentFilterDTO filter)
		{
			bool result = false;
			result =  await _employeeTrainingDocumentLogic.UpdateEmployeeTrainingDocument(id, filter);
			return result;
		}
	}
}
