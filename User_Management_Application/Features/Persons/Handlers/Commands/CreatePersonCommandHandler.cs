using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Features.Persons.Requests.Commands;
using User_Management_Application.Persistance.Contract;
using User_Management_Application.Persistance.Implement;
using User_Management_Domain;

namespace User_Management_Application.Features.Persons.Handlers.Commands
{
	public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
	{
		private readonly IPersonRepository personRepository;
		private readonly IMapper mapper;

		public CreatePersonCommandHandler(IPersonRepository personRepository , IMapper mapper)
		{
			this.personRepository = personRepository;
			this.mapper = mapper;
		}

		public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
		{
			var person= mapper.Map<Person>(request.PersonDto);
			person = await personRepository.Create(person);
			return person.Id;
		}
	}
}
