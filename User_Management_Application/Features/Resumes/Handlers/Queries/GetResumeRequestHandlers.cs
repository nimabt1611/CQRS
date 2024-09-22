using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Resume;
using User_Management_Application.Features.Resumes.Requests.Queries;
using User_Management_Application.Persistance.Contract;

namespace User_Management_Application.Features.Resumes.Handlers.Queries
{
	public class GetResumeRequestHandlers : IRequestHandler<GetResumeRequest, ResumeDto>
	{
		private readonly IResumeRepository resumeRepository;
		private readonly IMapper mapper;

		public GetResumeRequestHandlers(IResumeRepository resumeRepository , IMapper mapper)
		{
			this.resumeRepository = resumeRepository;
			this.mapper = mapper;
		}

		public async Task<ResumeDto> Handle(GetResumeRequest request, CancellationToken cancellationToken)
		{
			var resume = await resumeRepository.Get(request.Id);
			return mapper.Map<ResumeDto>(resume);		
		}
	}
}
