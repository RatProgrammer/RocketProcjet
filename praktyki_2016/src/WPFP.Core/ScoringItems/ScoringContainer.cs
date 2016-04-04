using System.IO;
using System.Security.Policy;
using WPFP.CommunicationLayer.DTO;
using WPFP.Core.ParsingStuff;

namespace WPFP.Core.ScoringItems
{
    public class ScoringContainer
    {
        public double Budget { get; set; }
        public double Engineers { get; set; }
        public double Scientists { get; set; }
        public double Popularity { get; set; }
    }
}

