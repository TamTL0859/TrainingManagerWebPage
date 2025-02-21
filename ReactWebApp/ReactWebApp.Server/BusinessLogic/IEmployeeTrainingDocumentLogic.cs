using ReactWebAppServer.Model;

namespace ReactWebAppServer.BusinessLogic
{
	public interface IEmployeeTrainingDocumentLogic
	{
		public List<EmployeeTrainingDocument> GetEmployeeTrainingDocuments(int employeeID);
	}
}
