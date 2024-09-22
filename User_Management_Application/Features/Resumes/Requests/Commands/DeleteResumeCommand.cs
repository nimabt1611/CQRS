using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application.Features.Resumes.Requests.Commands
{
	public class DeleteResumeCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
