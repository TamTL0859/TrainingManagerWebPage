using TrainingManagerAPI.DataAccess;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.BusinessLogic
{
	public class TrainingDocumentLogic
	{
		private readonly TrainingDocumentAccess _dataAccess;

		public TrainingDocumentLogic(TrainingDocumentAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public TrainingDocument GetTrainingDocument(int trainingDocumentID)
		{
			TrainingDocument trainingDocument = _dataAccess.getTrainingDocument(trainingDocumentID);
			return trainingDocument;
		}
	}
}
