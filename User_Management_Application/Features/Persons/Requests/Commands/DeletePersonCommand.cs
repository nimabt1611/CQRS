using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application.Features.Persons.Requests.Commands
{
	public class DeletePersonCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
