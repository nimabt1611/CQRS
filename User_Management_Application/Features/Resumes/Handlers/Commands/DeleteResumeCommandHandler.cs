using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Features.Resumes.Requests.Commands;
using User_Management_Application.Persistance.Contract;
using User_Management_Domain;

namespace User_Management_Application.Features.Resumes.Handlers.Commands
{
	public class DeleteResumeCommandHandler : IRequestHandler<DeleteResumeCommand , Unit>
	{
		private readonly IResumeRepository resumeRepository;
		private readonly IMapper mapper;

		public DeleteResumeCommandHandler( IResumeRepository resumeRepository , IMapper mapper)
		{
			this.resumeRepository = resumeRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
		{
			var Resume = await resumeRepository.Get(request.Id);
			if (Resume == null)
				throw new ValidationException();
			await resumeRepository.Delete(request.Id,Resume);
			return Unit.Value;
		}
	}
}
