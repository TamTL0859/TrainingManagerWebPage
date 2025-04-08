using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.DataAccess
{
	public interface IEmployeeTrainingDocumentAccess
	{
		public Task<EmployeeTrainingDocument> getEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID);
		public Task<List<EmployeeTrainingDocument>> getEmployeeTrainingDocuments(int employeeID);
		public Task<bool> UpdateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocumentFilterDTO filter);
		public Task<bool> CreateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocument employeeTrainingDocument);
	}
}
