using TrainingManagerAPI.DTO;

namespace TrainingManagerAPI.BusinessLogic
{
	public interface IEmployeeLogic
	{
		public EmployeeViewDTO getEmployee(int employeeID);

		public List<EmployeeViewDTO> GetEmployees();
	}
}
