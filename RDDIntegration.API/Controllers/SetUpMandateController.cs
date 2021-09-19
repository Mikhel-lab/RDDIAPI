using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.SetUpMandate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SetUpMandateController : ControllerBase
	{
		private readonly ISetupMandate _set;
		public SetUpMandateController(ISetupMandate set)
		{
			_set = set;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Post([FromBody] SetUpMandateRequest request)
		{

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _set.SetUpManDatee(request);

			return Ok();
		}
	}
}
