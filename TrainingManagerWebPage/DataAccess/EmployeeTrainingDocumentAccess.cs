using Dapper;
using Microsoft.Data.SqlClient;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
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
			string getEmployeeTrainingDocumentsQuery = "SELECT d.documentTitle, d.pointsGoal, d.pointsStatus, d.trainingRequired, d.trainingStatus, d.trainingtype, td.trainingDocumentID, e.employeeID " +
				"FROM EmployeeTrainingDocuments d " +
				"LEFT JOIN TrainingDocuments td ON d.fk_trainingDocumentID = td.trainingDocumentID " +
				"LEFT JOIN Employees e ON d.fk_employeeID = e.employeeID " +
				"WHERE d.fk_employeeID = @EmployeeID";

			using (SqlConnection connection = new(_connectionString))
			{
				employeeTrainingDocuments = connection.Query<EmployeeTrainingDocument, TrainingDocument, Employee, EmployeeTrainingDocument>(getEmployeeTrainingDocumentsQuery, (etd, td, e) =>
				{
					etd.TrainingDocumentID = td.TrainingDocumentID;
					etd.EmployeeID = e.EmployeeID;
					return etd;
				}, new { EmployeeID = employeeID },
				splitOn: "trainingDocumentID, employeeID"
				).ToList();
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
