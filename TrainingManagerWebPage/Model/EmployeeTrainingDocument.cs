using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerAPI.Model
{
	public class EmployeeTrainingDocument : TrainingDocument
	{
		public int? EmployeeID { get; set; }
		public required int PointsStatus { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public required TrainingRequired TrainingRequired { get; set; }
	}
}
