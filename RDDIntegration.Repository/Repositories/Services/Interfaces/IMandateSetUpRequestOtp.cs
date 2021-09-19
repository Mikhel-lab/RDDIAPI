using RDDIntegration.Models.Request.MandateActivateRequestOtps;
using RDDIntegration.Models.Response.MandateActivateRequestOtpResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Interfaces
{
	public interface IMandateSetUpRequestOtp
	{
		Task<MandateActivateRequestOtpResponse> RequestOtpResponse(MandateActivateRequestOtp request);
	}
}
