using System.Collections.Generic;
using TrainingManagerAPI.DataAccess;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.BusinessLogic
{
	public class EmployeeTrainingDocumentLogic : IEmployeeTrainingDocumentLogic
	{
		private readonly IEmployeeTrainingDocumentAccess _dataAccess;

		public EmployeeTrainingDocumentLogic(EmployeeTrainingDocumentAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public List<EmployeeTrainingDocument> GetEmployeeTrainingDocuments(int employeeID)
		{
			List<EmployeeTrainingDocument> employeeTrainingDocuments = _dataAccess.getEmployeeTrainingDocuments(employeeID);
			return employeeTrainingDocuments;
		}
	}
}
