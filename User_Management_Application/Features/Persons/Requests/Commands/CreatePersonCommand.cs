using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Person;

namespace User_Management_Application.Features.Persons.Requests.Commands
{
	public class CreatePersonCommand : IRequest<int>
	{
		public CreatePersonDto PersonDto { get; set; }
	}
}
