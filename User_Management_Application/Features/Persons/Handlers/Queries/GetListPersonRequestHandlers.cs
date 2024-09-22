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
	public class GetListPersonRequestHandlers : IRequestHandler<GetListPersonRequest, List<PersonDto>>
	{
		private readonly IPersonRepository personRepository;
		private readonly IMapper mapper;

		public GetListPersonRequestHandlers( IPersonRepository personRepository , IMapper mapper)
		{
			this.personRepository = personRepository;
			this.mapper = mapper;
		}

		public async Task<List<PersonDto>> Handle(GetListPersonRequest request, CancellationToken cancellationToken)
		{
			var person = await personRepository.GetAll();
			return mapper.Map<List<PersonDto>>(person);
		}
	}
}
