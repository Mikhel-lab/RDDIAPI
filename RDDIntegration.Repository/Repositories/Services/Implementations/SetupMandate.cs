using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RDDIntegration.API.Extensions;
using RDDIntegration.API.Services.Interfaces;
using RDDIntegration.Models.Request.SetUpMandate;
using RDDIntegration.Models.Response.SetUpManadate;
using RDDIntegration.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RDDIntegration.API.Services.Implementations
{
	public class SetupMandate :  ISetupMandate
	{
        private IOptions<ConfigSettings> _configSettings;
        private string _remitaBaseUrl;
        private readonly HttpClient _client;
        private readonly string _merchantId;
        private readonly string _serviceTypeId;
        private readonly string _requestId;
        private readonly string _mandateSetUpUrl;
        private readonly string _requestAuthorization;
        private readonly string _apiKey;
        private readonly string _apitoken;
        private readonly string _mandateId;
        private string _hash;
        private string _apihash;
        private string _mandateType;
        public SetupMandate(IOptions<ConfigSettings> configSettings, string mandateType = "DD", string mandateSetUpUrl = "/setup", string merchantId = "27768931", string serviceTyeId = "35126630", string apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==")
        {
            _configSettings = configSettings;
            _requestId = DateTime.Now.Ticks.ToString();
            _merchantId = merchantId;
            _serviceTypeId = serviceTyeId;
            _mandateSetUpUrl = mandateSetUpUrl;
            _apiKey = apiKey;
            _mandateType = mandateType;
            _client = new HttpClient();

        }

        public async Task<SetUpManadetResponse> SetUpManDatee(SetUpMandateRequest request)
		{
            try
            {
                _hash = Utilility.SHA512Hash(_merchantId + _serviceTypeId + _requestId + request.amount + _apiKey);

                request.hash = _hash;
                request.mandateType = _mandateType;
                request.requestId = _requestId;
                request.serviceTypeId = _serviceTypeId;
                request.mandateType = _mandateType;
                request.merchantId = _merchantId;
                request.startDate = Convert.ToDateTime(request.startDate).ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                request.endDate = Convert.ToDateTime(request.endDate).ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                _client.BaseAddress = new Uri($"{_configSettings.Value.RemitaBaseUrl}{_mandateSetUpUrl}");

                var payLoad = JsonConvert.SerializeObject(request);
                var content = new StringContent(payLoad, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
					var resultStream = await response.Content.ReadAsStreamAsync();
					var returnResult = ServiceInjectionExtension.DeserializeEmbeddedJsonP<SetUpManadetResponse>(resultStream);
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
