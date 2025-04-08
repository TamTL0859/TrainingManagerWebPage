using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.BusinessLogic
{
	public interface IEmployeeTrainingDocumentLogic
	{
		public Task<List<EmployeeTrainingDocument>> GetEmployeeTrainingDocuments(int employeeID);
		public Task<bool> UpdateEmployeeTrainingDocument(int id , EmployeeTrainingDocumentFilterDTO filter);
	}
}
