using ReactWebAppServer.DTO;
using ReactWebAppServer.Model;

namespace ReactWebAppServer.BusinessLogic
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
