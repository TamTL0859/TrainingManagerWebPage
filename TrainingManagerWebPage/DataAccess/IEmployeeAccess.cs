using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
{
	public interface IEmployeeAccess
	{
		public Employee getEmployee(int employeeID);

		public List<Employee> getEmployees();
	}
}
