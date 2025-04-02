using TrainingManagerAPI.DTO;
using TrainingManagerAPI.Model;
using TrainingManagerAPI.Model.Enum;

namespace TrainingManagerWebPage.DTO
{
	public class Converter
	{
		public static EmployeeViewDTO FromEmployee(Employee employee)
		{
			EmployeeViewDTO employeeViewDTO = new()
			{
				EmployeeID = employee.EmployeeID,
				EmployeeTrainingDocumentInformation = new EmployeeTrainingDocumentViewDTOInformation()
				{
					TotalPointsStatus = employee.EmployeeTrainingDocuments.Sum(etd => etd.PointsStatus),
					TotalPointsGoal = employee.EmployeeTrainingDocuments.Sum(etd => etd.PointsGoal),
					PointsDifference = (employee.EmployeeTrainingDocuments.Sum(etd => (decimal)etd.PointsStatus) / employee.EmployeeTrainingDocuments.Sum(etd => (decimal)etd.PointsGoal) * 100).ToString("0.00") + "%",
					DocumentsCount = employee.EmployeeTrainingDocuments.Count,
				},
				EmployeeTrainingDocuments = employee.EmployeeTrainingDocuments,
				ProfilePicture = employee.ProfilePicture,
				Username = employee.Username,
				Role = (Role)(int)employee.Role,
				
			};


			return employeeViewDTO;
		}

		public static List<EmployeeTrainingDocument> ToEnum(List<EmployeeTrainingDocument> etds)
		{
			foreach(EmployeeTrainingDocument etd in etds)
			{
				etd.TrainingStatus = (TrainingStatus)(int)etd.TrainingStatus;
				etd.TrainingRequired = (TrainingRequired)(int)etd.TrainingRequired;
				etd.TrainingType = (TrainingType)(int)etd.TrainingType;

			}
			return etds;
		} 
	}
}
