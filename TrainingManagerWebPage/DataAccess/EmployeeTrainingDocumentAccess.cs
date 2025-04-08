using Dapper;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.DataAccess
{
	public class EmployeeTrainingDocumentAccess : IEmployeeTrainingDocumentAccess
	{
		private readonly string _connectionString;
		public EmployeeTrainingDocumentAccess(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Missing ConnectionString from configuration");
		}


		public async Task<List<EmployeeTrainingDocument>> getEmployeeTrainingDocuments(int employeeID)
		{
			List<EmployeeTrainingDocument> employeeTrainingDocuments = [];
			string getEmployeeTrainingDocumentsQuery = "SELECT d.documentTitle, d.pointsGoal, d.pointsStatus, d.trainingRequired, d.trainingStatus, d.trainingtype, td.trainingDocumentID, e.employeeID " +
				"FROM EmployeeTrainingDocuments d " +
				"LEFT JOIN TrainingDocuments td ON d.fk_trainingDocumentID = td.trainingDocumentID " +
				"LEFT JOIN Employees e ON d.fk_employeeID = e.employeeID " +
				"WHERE d.fk_employeeID = @EmployeeID";

			using (SqlConnection connection = new(_connectionString))
			{
				employeeTrainingDocuments = (List<EmployeeTrainingDocument>)await connection.QueryAsync<EmployeeTrainingDocument, TrainingDocument, Employee, EmployeeTrainingDocument>(getEmployeeTrainingDocumentsQuery, (etd, td, e) =>
				{
					etd.TrainingDocumentID = td.TrainingDocumentID;
					etd.EmployeeID = e.EmployeeID;
					return etd;
				}, new { EmployeeID = employeeID },
				splitOn: "trainingDocumentID, employeeID"
				);
			}

			return employeeTrainingDocuments;
		}
		public async Task<EmployeeTrainingDocument> getEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UpdateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocumentFilterDTO filter)
		{
			int result = 0;
			string query = "";
			DynamicParameters parameters = new();
			query = ApplyFilter(employeeID, filter, parameters);
			parameters.Add("DocumentID", filter.TrainingDocumentID);
			parameters.Add("EmployeeID", employeeID);

			try
			{
				using (SqlConnection connection = new(_connectionString))
				{
					result = await connection.ExecuteAsync(query, parameters);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error", ex);
			}

			return result > 0;
		}
		public async Task<bool> CreateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocument employeeTrainingDocument)
		{
			throw new NotImplementedException();
		}

		private string ApplyFilter(int employeeID, EmployeeTrainingDocumentFilterDTO filter, DynamicParameters parameters)
		{
			if (filter.StatusPoints != null && filter.TrainingStatus != null)
			{
				parameters.Add("pointsStatus", filter.StatusPoints);
				parameters.Add("trainingStatus", (int)filter.TrainingStatus!);
				return "UPDATE EmployeeTrainingDocuments SET pointsStatus = @pointsStatus, trainingStatus = @trainingStatus WHERE fk_trainingDocumentID = @DocumentID AND fk_employeeID = @EmployeeID";
			}
			if (filter.StatusPoints != null)
			{
				parameters.Add("pointsStatus", filter.StatusPoints);
				return "UPDATE EmployeeTrainingDocuments SET pointsStatus = @pointsStatus WHERE fk_trainingDocumentID = @DocumentID AND fk_employeeID = @EmployeeID";
			}
			if (filter.TrainingRequired != null)
			{
				parameters.Add("trainingRequired", (int)filter.TrainingRequired!);
				return "UPDATE EmployeeTrainingDocuments SET trainingRequired = @trainingRequired WHERE fk_trainingDocumentID = @DocumentID AND fk_employeeID = @EmployeeID";
			}
			if (filter.TrainingStatus != null)
			{
				parameters.Add("trainingStatus", (int)filter.TrainingStatus!);
				return "UPDATE EmployeeTrainingDocuments SET trainingStatus = @trainingStatus WHERE fk_trainingDocumentID = @DocumentID AND fk_employeeID = @EmployeeID";
			}

			return "";
		}
	}
}
