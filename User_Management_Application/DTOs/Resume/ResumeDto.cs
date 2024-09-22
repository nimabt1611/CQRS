using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Person;

namespace User_Management_Application.DTOs.Resume
{
	public class ResumeDto
	{
		public string LastJob { get; set; }
		public int LastSalary { get; set; }
		public PersonDto person { get; set; }
		public int personId { get; set; }
	}
}
