using TrainingManagerAPI.DTO;
using TrainingManagerAPI.Model;

namespace TrainingManagerAPI.BusinessLogic
{
	public class DTOConverter
	{
		public static EmployeeViewDTO FromEmployee(Employee employee)
		{
			EmployeeViewDTO employeeViewDTO = new()
			{
				EmployeeID = employee.EmployeeID,
				EmployeeTrainingDocuments = employee.EmployeeTrainingDocuments,
				ProfilePicture = employee.ProfilePicture,
				Username = employee.Username
			};

			return employeeViewDTO;
		}
	}
}
