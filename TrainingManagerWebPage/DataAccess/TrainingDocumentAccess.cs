using Dapper;
using Microsoft.Data.SqlClient;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
{
	public class TrainingDocumentAccess : ITrainingDocumentAccess
	{
		private readonly string _connectionString;
		public TrainingDocumentAccess(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Missing ConnectionString from configuration");
		}
		public TrainingDocument getTrainingDocument(int trainingDocumentID)
		{
			TrainingDocument trainingDocument;

			string getDocumentQuery = "Select * FROM TrainingDocuments WHERE trainingDocumentID = @trainingDocumentID";

			using (SqlConnection connection = new(_connectionString))
			{
				trainingDocument = connection.Query<TrainingDocument>(getDocumentQuery, new { TrainingDocumentID = trainingDocumentID }).First();
			}
			
			return trainingDocument;
		}
	}
}
