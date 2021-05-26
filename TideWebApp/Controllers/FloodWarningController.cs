using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller to retrieve flood warnings
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FloodWarningController : ControllerBase
    {

        public readonly ILogger<FloodWarningController> _logger;
        public IGetFloodWarningService _getFloodWarningService;

        /// <summary>
        /// Injection constructor for FloodWarningController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="getFloodWarningService"></param>
        public FloodWarningController(ILogger<FloodWarningController> logger, IGetFloodWarningService getFloodWarningService)
        {
            _logger = logger;
            _getFloodWarningService = getFloodWarningService;
        }

        /// <summary>
        /// Getter for flood warnings from external API. Calls GetFloodWarningService
        /// </summary>
        /// <param name="region">Also known as county. The name of the region, or the string it's expected to contain</param>
        /// <param name="pageSize">Size of the page. Defaults to 5</param>
        /// <param name="pageNum">Number of the page. Defaults to 1</param>
        /// <returns>List of FloodWarning objects</returns>
        [HttpGet]
        public async Task<List<FloodWarning>> Get(string region, int pageSize = 5, int pageNum = 1)
        {
            try
            {
                if (region == null)
                {
                    throw new ArgumentNullException("region");
                }
                _logger.LogDebug($"Getting flood warning for region: '{region}' at {DateTime.Now}");
                return await _getFloodWarningService.GetFloodWarningsAsync(region, pageSize, pageNum);
            }
            catch(ArgumentNullException e)
            {
                _logger.LogError("Region is not specified");
                return null;
            }
            catch(Exception e)
            {
                _logger.LogError($"Failed to get information for region '{region}', reason {e}");
                return null;
            }
        }
    }
}
