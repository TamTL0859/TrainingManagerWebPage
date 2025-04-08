using System.Collections.Generic;
using TrainingManagerAPI.DataAccess;
using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.BusinessLogic
{
	public class EmployeeTrainingDocumentLogic : IEmployeeTrainingDocumentLogic
	{
		private readonly IEmployeeTrainingDocumentAccess _dataAccess;

		public EmployeeTrainingDocumentLogic(EmployeeTrainingDocumentAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<List<EmployeeTrainingDocument>> GetEmployeeTrainingDocuments(int employeeID)
		{
			List<EmployeeTrainingDocument> employeeTrainingDocuments = await _dataAccess.getEmployeeTrainingDocuments(employeeID);
			return employeeTrainingDocuments;
		}

		public async Task<bool> UpdateEmployeeTrainingDocument(int id, EmployeeTrainingDocumentFilterDTO filter)
		{
			bool result = false;
			result = await _dataAccess.UpdateEmployeeTrainingDocument(id, filter);
			return result;
		}

	}
}
