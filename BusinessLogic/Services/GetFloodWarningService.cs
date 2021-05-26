using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service to retrieve flood data from external API
    /// </summary>
    public class GetFloodWarningService : IGetFloodWarningService
    {
        IHttpClientFactory _clientFactory;
        private readonly ILogger<GetFloodWarningService> _logger;

        /// <summary>
        /// Injection constructor for GetFloodWarningService
        /// </summary>
        /// <param name="clientFactory"></param>
        /// <param name="logger"></param>
        public GetFloodWarningService(IHttpClientFactory clientFactory, ILogger<GetFloodWarningService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Async function to get all flood warnings matching the query from the external API
        /// </summary>
        /// <param name="county">The name of the county, or what the county name is expected to contain</param>
        /// <param name="pageSize">The size of the page (defaults to 5)</param>
        /// <param name="pageNum">The number of the page (defaults to 1)</param>
        /// <returns>Async list of FloodWarning objects</returns>
        public async Task<List<FloodWarning>> GetFloodWarningsAsync(string county, int pageSize = 5, int pageNum = 1)
        {
            _logger.LogInformation($"Requesting from remote server at {DateTime.Now}, params county: {county}, pageSize: {pageSize}, pageNum: {pageNum}");
            var client = _clientFactory.CreateClient("remote");
            var request = new HttpRequestMessage(HttpMethod.Get, $"?county={county}&_limit={pageSize}&_offset={pageNum * pageSize - pageSize}");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                FloodWarningContainer floodWarningContainer = JsonConvert.DeserializeObject<FloodWarningContainer>(responseString);

                List <FloodWarning> floodWarnings = floodWarningContainer.items;

                _logger.LogTrace($"Successfully returned data from remote server at {DateTime.Now}, params county: {county}, pageSize: {pageSize}, pageNum: {pageNum}");

                return floodWarnings;
            }
            else
            {
                _logger.LogError($"The remote server returned an error {response.StatusCode} at {DateTime.Now}, params county: {county}, pageSize: {pageSize}, pageNum: {pageNum}");
                return null;
            }
        }
    }
}
