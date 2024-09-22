using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.API.CustomActionFilters;
using User_Management_Application.DTOs.Person;
using User_Management_Application.Features.Persons.Requests.Commands;
using User_Management_Application.Features.Persons.Requests.Queries;
using User_Management_Application.Persistance.Contract;
using User_Management_dataAccess;
using User_Management_Domain;

namespace User_Management_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IMediator mediator;

		public PersonController(IMediator mediator)
		{

			this.mediator = mediator;
		}

		[HttpGet]
		[Authorize(Roles = "Reader , Writer")]
		public async Task<ActionResult<List<Person>>> GetAll()
		{
			var person = await mediator.Send(new GetListPersonRequest());
			return Ok(person);
		}

		[HttpGet]
		[Route("{id:int}")]
		[Authorize(Roles = "Reader , Writer")]

		public async Task<IActionResult> Get (int id)
		{
			var person = await mediator.Send(new GetPersonRequest { Id = id });
			return Ok(person);
		}
		[HttpPost]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Create([FromBody] CreatePersonDto createPersonDto)
		{
			var person = new CreatePersonCommand { PersonDto = createPersonDto };
			var response = await mediator.Send(person);
			return Ok(response);
		}
		[HttpPut]
		[Route("{id:int}")]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult>Update(int id , [FromBody] UpdatePersonDto updatePersonDto)
		{
			
			var person = new UpdatePersonCommand { PersonDto = updatePersonDto };
			await mediator.Send(person);
			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}")]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult>Delete(int id)
		{

			var person = new DeletePersonCommand { Id = id };
			await mediator.Send(person);
			return NoContent();
		}
	}
}
