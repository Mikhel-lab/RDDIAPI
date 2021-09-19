using RDDIntegration.Models.Request.MandateStop;
using RDDIntegration.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Interfaces
{
	public interface IStopMandate
	{
		Task<StopMandateResponse> StopMandates(StopMandateRequest request);
	}
}
