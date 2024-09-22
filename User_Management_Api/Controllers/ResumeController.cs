using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using User_Management_Application.DTOs.Person;
using User_Management_Application.DTOs.Resume;
using User_Management_Application.Features.Persons.Requests.Commands;
using User_Management_Application.Features.Persons.Requests.Queries;
using User_Management_Application.Features.Resumes.Requests.Commands;
using User_Management_Application.Features.Resumes.Requests.Queries;
using User_Management_Domain;

namespace User_Management_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResumeController : ControllerBase
	{
		private readonly IMediator mediator;

		public ResumeController(IMediator mediator)
		{

			this.mediator = mediator;
		}

		[HttpGet]
		[Authorize(Roles = "Reader , Writer")]
		public async Task<ActionResult<List<Resume>>> GetAll()
		{
			var resume = await mediator.Send(new GetListResumeRequest());
			return Ok(resume);
		}

		[HttpGet]
		[Route("{id:int}")]
		[Authorize(Roles = "Reader , Writer")]

		public async Task<IActionResult> Get(int id)
		{
			var resume = await mediator.Send(new GetResumeRequest { Id = id });
			return Ok(resume);
		}
		[HttpPost]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Create([FromBody] CreateResumeDto createResumeDto)
		{
			var resume = new CreateResumeCommand { ResumeDto = createResumeDto };
			var response = await mediator.Send(resume);
			return Ok(response);
		}
		[HttpPut]
		[Route("{id:int}")]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateResumeDto updateResumeDto)
		{

			var resume = new UpdateResumeCommand { ResumeDto = updateResumeDto };
			await mediator.Send(resume);
			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}")]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Delete(int id)
		{

			var resume = new DeleteResumeCommand { Id = id };
			await mediator.Send(resume);
			return NoContent();
		}
	}
}

