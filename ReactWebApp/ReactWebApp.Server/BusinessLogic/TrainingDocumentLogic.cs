using ReactWebAppServer.DataAccess;
using ReactWebAppServer.Model;

namespace ReactWebAppServer.BusinessLogic
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
