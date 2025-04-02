using Azure.Identity;
using System.Text.Json.Serialization;
using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerAPI.Model
{
	public class Employee : Person
	{
		public int? EmployeeID { get; set; }
		public required string Username { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public required Role Role { get; set; }
		public required string Email { get; set; }
		public string? ProfilePicture { get; set; }
		public required List<EmployeeTrainingDocument> EmployeeTrainingDocuments { get; set; }
	}
}
