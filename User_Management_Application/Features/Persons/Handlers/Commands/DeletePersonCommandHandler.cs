using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
	public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
	{
		private readonly IPersonRepository personRepository;
		private readonly IMapper mapper;

		public DeletePersonCommandHandler(IPersonRepository personRepository , IMapper mapper)
		{
			this.personRepository = personRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
		{
			var person = await personRepository.Get(request.Id);
			if (person == null)
				throw new ValidationException();

			await personRepository.Delete(request.Id, person);
			return Unit.Value;
		}
	}
}
