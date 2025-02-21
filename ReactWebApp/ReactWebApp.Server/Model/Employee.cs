using ReactWebAppServer.Model.Enum;

namespace ReactWebAppServer.Model
{
	public class Employee : Person
	{
		public int? EmployeeID { get; set; }
		public required string Username { get; set; }
		public required Role Role { get; set; }
		public required string Email { get; set; }
		public string? ProfilePicture { get; set; }
		public required List<EmployeeTrainingDocument> EmployeeTrainingDocuments { get; set; }
	}
}
