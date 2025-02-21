using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
{
	public interface IEmployeeTrainingDocumentAccess
	{
		public EmployeeTrainingDocument getEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID);
		public List<EmployeeTrainingDocument> getEmployeeTrainingDocuments(int employeeID);
		public bool UpdateEmployeeTrainingDocument(int employeeID, int employeeTrainingDocumentID);
		public bool CreateEmployeeTrainingDocument(int employeeID, EmployeeTrainingDocument employeeTrainingDocument);
	}
}
