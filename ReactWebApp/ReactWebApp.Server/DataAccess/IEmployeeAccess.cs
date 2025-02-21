using ReactWebAppServer.Model;

namespace ReactWebAppServer.DataAccess
{
	public interface IEmployeeAccess
	{
		public Employee getEmployee(int employeeID);

		public List<Employee> getEmployees();
	}
}
