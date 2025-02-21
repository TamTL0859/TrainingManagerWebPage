using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.DTO
{
	public class EmployeeViewDTO
	{
		public int? EmployeeID { get; set; }
		public required string Username { get; set; }
		public string? ProfilePicture { get; set; }
		public required List<EmployeeTrainingDocument> EmployeeTrainingDocuments { get; set; }
	}
}
