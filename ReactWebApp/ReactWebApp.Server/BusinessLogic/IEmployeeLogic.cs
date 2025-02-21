using ReactWebAppServer.DTO;

namespace ReactWebAppServer.BusinessLogic
{
	public interface IEmployeeLogic
	{
		public EmployeeViewDTO getEmployee(int employeeID);

		public List<EmployeeViewDTO> GetEmployees();
	}
}
