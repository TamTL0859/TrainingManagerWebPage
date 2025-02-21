using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DataAccess
{
	public interface ITrainingDocumentAccess
	{
		public TrainingDocument getTrainingDocument(int trainingDocumentID);
	}
}
