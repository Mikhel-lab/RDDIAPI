using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RDDIntegration.API.Extensions;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.MandateActivateRequestOtps;
using RDDIntegration.Models.Response.MandateActivateRequestOtpResponses;
using RDDIntegration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Implementations
{
	public class MandateSetUpRequestOtp : IMandateSetUpRequestOtp
	{
        private readonly IOptions<ConfigSettings> _configSettings;
        private readonly HttpClient _client;
        private string _merchantId;
        private readonly string _requestId;
        private readonly string _requestAuthorizationUrl;
        private readonly string _apiKey;
        private readonly string _apitoken;
        private string _mandateId;
        private string _apihash;


        public MandateSetUpRequestOtp( IOptions<ConfigSettings> configSettings, string mandateId = "",
            string requestAuthorizationUrl = "/requestAuthorization", string merchantId = "27768931", string apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==", string apitoken = "SGlQekNzMEdMbjhlRUZsUzJCWk5saDB6SU14Zk15djR4WmkxaUpDTll6bGIxRCs4UkVvaGhnPT0=")
        {
            _configSettings = configSettings;
            _requestId = DateTime.Now.Ticks.ToString();
            _merchantId = merchantId;
            _mandateId = mandateId;
            _requestAuthorizationUrl = requestAuthorizationUrl;
            _apiKey = apiKey;
            _apitoken = apitoken;
            _client = new HttpClient();

        }
        public async Task<MandateActivateRequestOtpResponse> RequestOtpResponse(MandateActivateRequestOtp request)
		{
            try
            {
                _apihash = Utilility.SHA512Hash( _requestId + _apitoken + _apiKey);

                request.requestId = _requestId;
                request.mandateId = _mandateId;
                _client.BaseAddress = new Uri($"{_configSettings.Value.RemitaBaseUrl}{_requestAuthorizationUrl}");

                var payLoad = JsonConvert.SerializeObject(request);
                var content = new StringContent(payLoad, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultStream = await response.Content.ReadAsStreamAsync();
                    var returnResult = ServiceInjectionExtension.DeserializeEmbeddedJsonP<MandateActivateRequestOtpResponse>(resultStream);
                    return returnResult;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
	}
}
