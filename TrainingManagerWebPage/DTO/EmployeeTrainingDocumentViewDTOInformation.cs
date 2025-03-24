
namespace TrainingManagerWebPage.DTO
{
	public class EmployeeTrainingDocumentViewDTOInformation
	{
		public int? EmployeeID { get; set; }
		public int TotalPointsStatus { get; set; }
		public int TotalPointsGoal { get; set; }
		public string PointsDifference { get; set; } = string.Empty;

		public int DocumentsCount { get; set; }
	}
}
