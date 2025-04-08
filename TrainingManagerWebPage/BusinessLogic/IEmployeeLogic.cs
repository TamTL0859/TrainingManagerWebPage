using TrainingManagerAPI.DTO;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.BusinessLogic
{
	public interface IEmployeeLogic
	{
		public Task<EmployeeViewDTO> GetEmployee(int employeeID);
		public Task<List<EmployeeViewDTO>> GetEmployees();
		public Task<bool> UpdateEmployeeTrainingDocumentBasedOnFilter(int id, EmployeeTrainingDocumentFilterDTO filter);
	}
}
