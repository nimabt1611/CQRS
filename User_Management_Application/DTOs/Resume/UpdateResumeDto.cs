using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Common;
using User_Management_Application.DTOs.Person;

namespace User_Management_Application.DTOs.Resume
{
	public class UpdateResumeDto : BaseDto
	{
		public string LastJob { get; set; }
		public int LastSalary { get; set; }
	}
}
