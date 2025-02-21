using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.BusinessLogic
{
	public interface ITrainingDocumentLogic
	{
		public TrainingDocument GetTrainingDocument(int trainingDocumentID);
	}
}
