using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class FloodWarning
    {
        public string description { get; set; }
        public string eaAreaName { get; set; }
        public string message { get; set; }
        public string severity { get; set; }
        public int severityLevel { get; set; }
        public FloodArea floodArea { get; set; }
    }

    public class FloodArea
    {
        public string county { get; set; }
        public string riverOrSea { get; set; }
    }

    public class FloodWarningContainer
    {
        public List<FloodWarning> items { get; set; }
    }
}
