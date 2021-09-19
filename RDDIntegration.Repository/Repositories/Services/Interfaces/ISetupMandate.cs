using RDDIntegration.Models.Request.SetUpMandate;
using RDDIntegration.Models.Response.SetUpManadate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Interfaces
{
	public interface ISetupMandate
	{
		Task<SetUpManadetResponse> SetUpManDatee(SetUpMandateRequest request);
	}
}
