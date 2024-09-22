using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Common;
using User_Management_Application.DTOs.Person;
using User_Management_Application.Features.Resumes.Requests.Commands;

namespace User_Management_Application.DTOs.Resume
{
	public class CreateResumeDto 
	{
        public int PersonId { get; set; }

        public string LastJob { get; set; }
		public int LastSalary { get; set; }

		
	}
}
