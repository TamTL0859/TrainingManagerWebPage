using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerAPI.Model
{
	public class TrainingDocument
	{
		public int? TrainingDocumentID { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public required TrainingType TrainingType { get; set; }
		public required string DocumentTitle { get; set; }
		public required int PointsGoal { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public required TrainingStatus TrainingStatus { get; set; }
	}
}
