using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Features.Persons.Requests.Commands;
using User_Management_Application.Persistance.Contract;
using User_Management_Application.Persistance.Implement;

namespace User_Management_Application.Features.Persons.Handlers.Commands
{
	public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
	{
		private readonly IPersonRepository personRepository;
		private readonly IMapper mapper;

		public UpdatePersonCommandHandler(IPersonRepository personRepository , IMapper mapper)
		{
			this.personRepository = personRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
		{
			var person = await personRepository.Get(request.PersonDto.Id);
			if (person == null)
				throw new ValidationException();

			mapper.Map(request.PersonDto, person);
			await personRepository.Update(request.PersonDto.Id, person);

			return Unit.Value;
		}
	}
}
