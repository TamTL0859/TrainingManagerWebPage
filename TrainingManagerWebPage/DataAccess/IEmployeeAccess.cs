using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
{
	public interface IEmployeeAccess
	{
		public Task<Employee> getEmployee(int employeeID);
		public Task<List<Employee>> getEmployees();
	}
}
