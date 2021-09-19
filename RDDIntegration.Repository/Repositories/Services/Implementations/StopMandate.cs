using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RDDIntegration.API.Extensions;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.MandateStop;
using RDDIntegration.Models.Response;
using RDDIntegration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Implementations
{
	public class StopMandate : IStopMandate
	{
        private readonly IOptions<ConfigSettings> _configSettings;
        private readonly HttpClient _client;
        private readonly string _merchantId;
        private readonly string _requestId;
        private readonly string _stopmandatepUrl;
        private readonly string _apiKey;
        private readonly string _mandateId;
        private string _hash;

		public StopMandate(IOptions<ConfigSettings> configSettings, string mandateId = "220008219056", string stopmandateUrl = "/stop", string merchantId = "27768931", string requestId = "1621514534606",  string apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==")
        {
            _configSettings = configSettings;
            _requestId = requestId;
            _merchantId = merchantId;
            _stopmandatepUrl = stopmandateUrl;
            _apiKey = apiKey;
            _mandateId = mandateId;
            _client = new HttpClient();

        }
        public async Task<StopMandateResponse> StopMandates(StopMandateRequest request)
		{
            try
            {
                _hash = Utilility.SHA512Hash(_merchantId + _mandateId + _requestId  + _apiKey);

                request.hash = _hash;
                request.requestId = _requestId;
                request.merchantId = _merchantId;
                request.mandateId = _mandateId;
                _client.BaseAddress = new Uri($"{_configSettings.Value.RemitaBaseUrl}{_stopmandatepUrl}");

                var payLoad = JsonConvert.SerializeObject(request);
                var content = new StringContent(payLoad, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultStream = await response.Content.ReadAsStreamAsync();
                    var returnResult = ServiceInjectionExtension.DeserializeEmbeddedJsonP<StopMandateResponse>(resultStream);
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
