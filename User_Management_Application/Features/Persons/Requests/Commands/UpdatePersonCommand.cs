using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Person;

namespace User_Management_Application.Features.Persons.Requests.Commands
{
	public class UpdatePersonCommand : IRequest<Unit>
	{
		public UpdatePersonDto PersonDto { get; set; }
	}
}
