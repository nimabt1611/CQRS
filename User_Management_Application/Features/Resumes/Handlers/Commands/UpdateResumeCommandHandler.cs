using AutoMapper;
using MediatR;
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
	public class UpdateResumeCommandHandler : IRequestHandler<UpdateResumeCommand, Unit>
	{
		private readonly IResumeRepository resumeRepository;
		private readonly IMapper mapper;

		public UpdateResumeCommandHandler(IResumeRepository resumeRepository , IMapper mapper )
		{
			this.resumeRepository = resumeRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
		{
			var resume = await resumeRepository.Get(request.ResumeDto.Id);
			if (resume == null)
				throw new ValidationException();
			mapper.Map(request.ResumeDto,resume);
			await resumeRepository.Update( request.ResumeDto.Id , resume);

			return Unit.Value;

		}
	}
}
