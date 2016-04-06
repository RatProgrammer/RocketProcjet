using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.ScoringItems
{
    class ScoringWriter
    {
    
        public void WriteParameters(ReportInfo reportInfo)
        {
            double budget = reportInfo.Budget;
            double engineers = reportInfo.Engineers;
            double scientists = reportInfo.Scientists;
            double popularity = reportInfo.Popularity;
            StreamWriter streamWriter = new StreamWriter(@"parameters.txt", false);
            streamWriter.WriteLine(budget.ToString());
            streamWriter.WriteLine(engineers.ToString());
            streamWriter.WriteLine(scientists.ToString());
            streamWriter.WriteLine(popularity.ToString());
            streamWriter.Close();
        }
    }
}
