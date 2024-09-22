using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using User_Management_Application.DTOs.Resume;
using User_Management_Application.Features.Resumes.Requests.Commands;
using User_Management_Application.Persistance.Contract;
using User_Management_Domain;

namespace User_Management_Application.Features.Resumes.Handlers.Commands
{
	public class CreateResumeCommandHandlers : IRequestHandler<CreateResumeCommand, int>
	{
		private readonly IResumeRepository resumeRepository;
		private readonly IMapper mapper;

		public CreateResumeCommandHandlers( IResumeRepository resumeRepository , IMapper mapper)
		{
			this.resumeRepository = resumeRepository;
			this.mapper = mapper;
		}

		public async Task<int> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
		{
			var resume = mapper.Map<Resume>(request.ResumeDto);
			resume = await resumeRepository.Create(resume);
			return resume.Id;
		}
	}
}
