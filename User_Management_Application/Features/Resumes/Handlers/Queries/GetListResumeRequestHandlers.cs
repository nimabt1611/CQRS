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
	public class GetListResumeRequestHandlers : IRequestHandler<GetListResumeRequest, List<ResumeDto>>
	{
		private readonly IResumeRepository resumeRepository;
		private readonly IMapper mapper;

		public GetListResumeRequestHandlers(IResumeRepository resumeRepository , IMapper mapper )

		{
			this.resumeRepository = resumeRepository;
			this.mapper = mapper;
		}

		public async Task<List<ResumeDto>> Handle(GetListResumeRequest request, CancellationToken cancellationToken)
		{
			var resume = await resumeRepository.GetAll();
			return mapper.Map<List<ResumeDto>>(resume);
		}
	}
}
