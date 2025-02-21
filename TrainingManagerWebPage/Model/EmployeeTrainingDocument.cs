using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerAPI.Model
{
	public class EmployeeTrainingDocument : TrainingDocument
	{
		public int? EmployeeID { get; set; }
		public required int PointsStatus { get; set; }
		public required TrainingRequired TrainingRequired { get; set; }
	}
}
