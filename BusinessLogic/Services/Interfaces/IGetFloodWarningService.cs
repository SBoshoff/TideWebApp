using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Interface for service to retrieve flood data from external API
    /// </summary>
    public interface IGetFloodWarningService
    {
        /// <summary>
        /// Async function to get all flood warnings matching the query from the external API
        /// </summary>
        /// <param name="county">The name of the county, or what the county name is expected to contain</param>
        /// <param name="pageSize">The size of the page (defaults to 5)</param>
        /// <param name="pageNum">The number of the page (defaults to 1)</param>
        /// <returns>Async list of FloodWarning objects</returns>
        public Task<List<FloodWarning>> GetFloodWarningsAsync(string county, int pageSize, int pageNum);
    }
}
