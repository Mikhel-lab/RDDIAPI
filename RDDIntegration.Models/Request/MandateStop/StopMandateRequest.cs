using System;
using System.Collections.Generic;
using System.Text;

namespace RDDIntegration.Models.Request.MandateStop
{
    public class StopMandateRequest
    {
        public string merchantId { get; set; }
        public string hash { get; set; }
        public string mandateId { get; set; }
        public string requestId { get; set; }
    }
}
