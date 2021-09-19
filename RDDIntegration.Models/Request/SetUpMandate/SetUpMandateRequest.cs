using System;
using System.Collections.Generic;
using System.Text;

namespace RDDIntegration.Models.Request.SetUpMandate
{
	public class SetUpMandateRequest
	{
        public string amount { get; set; }
        public string endDate { get; set; }
        public string hash { get; set; }
        public string mandateType { get; set; }
        public string maxNoOfDebits { get; set; }
        public string merchantId { get; set; }
        public string payerAccount { get; set; }
        public string payerBankCode { get; set; }
        public string payerEmail { get; set; }
        public string payerName { get; set; }
        public string payerPhone { get; set; }
        public string requestId { get; set; }
        public string serviceTypeId { get; set; }
        public string startDate { get; set; }

    }
}
