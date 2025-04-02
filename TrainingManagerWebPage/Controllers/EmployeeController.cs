﻿using Microsoft.AspNetCore.Mvc;
using TrainingManagerAPI.BusinessLogic;
using TrainingManagerAPI.DTO;
using TrainingManagerAPI.Model;

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
        public EmployeeViewDTO Get(int id)
        {
            return _employeeLogic.getEmployee(id);
        }
		// POST api/<EmployeeController>
		[HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
