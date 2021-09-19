using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.MandateActivateRequestOtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestOtpResponseController : ControllerBase
	{
		private readonly IMandateSetUpRequestOtp set;
		public RequestOtpResponseController(IMandateSetUpRequestOtp set)
		{
			this.set = set;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Post([FromBody] MandateActivateRequestOtp request)
		{

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await set.RequestOtpResponse(request);

			return Ok();
		}
	}
}
