using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.MandateStop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StopMandateController : ControllerBase
	{
		private readonly IStopMandate _set;
		public StopMandateController(IStopMandate set)
		{
			_set = set;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Post([FromBody] StopMandateRequest request)
		{

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _set.StopMandates(request);

			return Ok();
		}
	}
}
