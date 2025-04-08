using Microsoft.AspNetCore.Mvc;
using TrainingManagerAPI.BusinessLogic;
using TrainingManagerAPI.DTO;
using TrainingManagerAPI.Model;
using TrainingManagerWebPage.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainingManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeLogic _employeeLogic;

		public EmployeeController(EmployeeLogic employeeLogic)
		{
			_employeeLogic = employeeLogic;
		}

		// GET: api/<EmployeeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new List<string>(["123", "1233"]);
			//_employeeLogic.GetEmployees();
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public async Task<EmployeeViewDTO> Get(int id)
		{
			return await _employeeLogic.GetEmployee(id);
		}
		// POST api/<EmployeeController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("updateETD/{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] EmployeeTrainingDocumentFilterDTO filter)
		{
			bool result = await _employeeLogic.UpdateEmployeeTrainingDocumentBasedOnFilter(id, filter);

			return result ? Ok() : BadRequest();
		}

		// DELETE api/<EmployeeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
