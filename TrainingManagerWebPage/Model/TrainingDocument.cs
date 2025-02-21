using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerAPI.Model
{
	public class TrainingDocument
	{
		public int? TrainingDocumentID { get; set; }
		public TrainingType? TrainingType { get; set; }
		public required string DocumentTitle { get; set; }
		public required int PointsGoal { get; set; }
		public required TrainingStatus TrainingStatus { get; set; }
	}
}
