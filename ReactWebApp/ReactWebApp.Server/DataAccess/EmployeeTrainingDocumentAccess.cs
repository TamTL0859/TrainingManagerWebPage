using Dapper;
using Microsoft.Data.SqlClient;
using ReactWebAppServer.Model;

namespace ReactWebAppServer.DataAccess
{
	public class EmployeeTrainingDocumentAccess : IEmployeeTrainingDocumentAccess
	{
		private readonly string _connectionString;
		public EmployeeTrainingDocumentAccess(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Missing ConnectionString from configuration");
		}


		public List<EmployeeTrainingDocument> getEmployeeTrainingDocuments(int employeeID)
		{
			List<EmployeeTrainingDocument> employeeTrainingDocuments = [];
			string getDocumentsQuery = "SELECT * FROM EmployeeTrainingDocuments where employeeID = @employeeID";

			using (SqlConnection connection = new(_connectionString))
			{
				employeeTrainingDocuments = connection.Query<EmployeeTrainingDocument>(getDocumentsQuery, new { EmployeeID = employeeID }).ToList();
			}

			return employeeTrainingDocuments;
		}
		public EmployeeTrainingDocument getEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID)
		{
			throw new NotImplementedException();
		}

		public bool UpdateEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID)
		{
			throw new NotImplementedException();
		}
		public bool CreateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocument employeeTrainingDocument)
		{
			throw new NotImplementedException();
		}
	}
}
