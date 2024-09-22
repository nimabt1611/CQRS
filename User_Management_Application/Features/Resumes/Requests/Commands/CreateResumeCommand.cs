using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Person;
using User_Management_Application.DTOs.Resume;

namespace User_Management_Application.Features.Resumes.Requests.Commands
{
	public class CreateResumeCommand : IRequest<int>
	{
		public CreateResumeDto ResumeDto { get; set; }

		public IRequest<object> toCommand()
		{
			throw new NotImplementedException();
		}
	}
}
