using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Person;
using User_Management_Application.Features.Persons.Requests.Queries;
using User_Management_Application.Persistance.Contract;

namespace User_Management_Application.Features.Persons.Handlers.Queries
{
	public class GetPersonRequestHandlers : IRequestHandler<GetPersonRequest, PersonDto>
	{
		private readonly IPersonRepository personRepository;
		private readonly IMapper mapper;

		public GetPersonRequestHandlers(IPersonRepository personRepository , IMapper mapper)
		{
			this.personRepository = personRepository;
			this.mapper = mapper;
		}

		public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
		{
			var person = await personRepository.Get(request.Id);
			return mapper.Map<PersonDto>(person);
		}
	}
}
