using TrainingManagerAPI.Model;
using TrainingManagerAPI.Model.Enum;
using TrainingManagerWebPage.DTO;

namespace TrainingManagerAPI.DTO
{
	public class EmployeeViewDTO
	{
		public int? EmployeeID { get; set; }
		public string Username { get; set; } = "NoUser";
		public string? ProfilePicture { get; set; }
		public EmployeeTrainingDocumentViewDTOInformation? EmployeeTrainingDocumentInformation { get; set; }
		public List<EmployeeTrainingDocument> EmployeeTrainingDocuments { get; set; } = [];
		public Role Role { get; set; }

	}
}
