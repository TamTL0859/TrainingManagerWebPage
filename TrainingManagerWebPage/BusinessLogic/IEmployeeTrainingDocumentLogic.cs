using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.BusinessLogic
{
	public interface IEmployeeTrainingDocumentLogic
	{
		public List<EmployeeTrainingDocument> GetEmployeeTrainingDocuments(int employeeID);
	}
}
