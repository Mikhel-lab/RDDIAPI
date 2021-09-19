using System;
using System.Collections.Generic;
using System.Text;

namespace RDDIntegration.Models.Response.MandateActivateRequestOtpResponses
{
    public class MandateActivateRequestOtpResponse
    {
        public string statuscode { get; set; }
        public List<AuthParam> authParams { get; set; }
        public string requestId { get; set; }
        public string mandateId { get; set; }
        public string remitaTransRef { get; set; }
        public string status { get; set; }
    }

    public class AuthParam
    {
        public string description2 { get; set; }
        public string label1 { get; set; }
        public string param1 { get; set; }
        public string label2 { get; set; }
        public string description1 { get; set; }
        public string param2 { get; set; }
    }
}
