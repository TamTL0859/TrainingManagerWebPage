using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using ReactWebAppServer.Model;

namespace ReactWebAppServer.DataAccess
{
	public class EmployeeAccess : IEmployeeAccess
	{
		private readonly string _connectionString;
		public EmployeeAccess(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Missing ConnectionString from configuration");
		}
		public Employee getEmployee(int employeeID)
		{
			Employee employee;

			string getEmployeeQuery = "Select * FROM Employees WHERE employeeID = @employeeID";

			using (SqlConnection connection = new(_connectionString))
			{
				employee = connection.Query<Employee>(getEmployeeQuery, new { EmployeeID = employeeID }).First();
			}

			return employee;
		}

		public List<Employee> getEmployees()
		{
			List<Employee> employees;

			string getEmployeeQuery = "Select * FROM Employees";

			using (SqlConnection connection = new(_connectionString))
			{
				employees = connection.Query<Employee>(getEmployeeQuery).ToList();
			}

			return employees;
		}
	}
}
