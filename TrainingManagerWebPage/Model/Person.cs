﻿namespace TrainingManagerAPI.Model
{
	public class Person
	{
		public int? PersonID { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string PhoneNumber { get; set; }
	}
}
