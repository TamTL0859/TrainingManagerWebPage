using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerWebPage.DTO
{
	public class EmployeeTrainingDocumentFilterDTO
	{
		public int TrainingDocumentID { get; set; }
		public int? StatusPoints { get; set; }
		public TrainingStatus? TrainingStatus { get; set; }
		public TrainingRequired? TrainingRequired { get; set; }
	}
}
