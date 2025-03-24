using Dapper;
using Microsoft.Data.SqlClient;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
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
			Employee? employee = null;

			string getEmployeeQuery = "SELECT e.employeeID, e.role, e.username, e.role, e.email, e.profilePicture, p.firstName, p.lastName, p.phoneNumber " +
				"FROM Employees e " +
				"LEFT JOIN Persons p ON e.fk_personID = p.personID " +
				"WHERE e.employeeID = @EmployeeID";
			try
			{
				using (SqlConnection connection = new(_connectionString))
				{
					employee = connection.Query<Employee>(getEmployeeQuery, new { EmployeeID = employeeID }).FirstOrDefault();
				}
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine(e + "not valid id");
			} catch (SqlException e)
			{
				Console.WriteLine(e);
			}
			return employee!;
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
