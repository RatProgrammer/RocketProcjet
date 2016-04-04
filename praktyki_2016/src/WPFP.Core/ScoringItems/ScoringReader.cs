using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFP.Core.ScoringItems
{
    class ScoringReader
    {
        public ScoringContainer ReadParameters()
        {
            StreamReader streamReader=new StreamReader(@"parameters.txt");
            ScoringContainer scoringContainer=new ScoringContainer();
            scoringContainer.Budget = Convert.ToDouble(streamReader.ReadLine());
            scoringContainer.Engineers = Convert.ToDouble(streamReader.ReadLine());
            scoringContainer.Scientists = Convert.ToDouble(streamReader.ReadLine());
            scoringContainer.Popularity = Convert.ToDouble(streamReader.ReadLine());
            streamReader.Close();
            return scoringContainer;

        }
    }
}
