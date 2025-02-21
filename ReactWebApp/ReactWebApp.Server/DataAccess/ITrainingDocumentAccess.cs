using ReactWebAppServer.Model;

namespace ReactWebAppServer.DataAccess
{
	public interface ITrainingDocumentAccess
	{
		public TrainingDocument getTrainingDocument(int trainingDocumentID);
	}
}
