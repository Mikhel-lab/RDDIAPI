using System;
using System.Collections.Generic;
using System.Text;

namespace RDDIntegration.Models.Response
{
	public class StopMandateResponse
	{
		public string statuscode { get; set; }
		public string requestId { get; set; }
		public string mandateId { get; set; }
		public string status { get; set; }
	}
}
