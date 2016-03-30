using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Xml;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.ParsingStuff
{
    class Parser
    {
        public static string ParsedLogs(ReportInfo fullReportInfo)
        {

            var parameters = GetParametersFromReportInfo(fullReportInfo);
            return $"{ParseToString(parameters)}{Environment.NewLine}{GetEvents(fullReportInfo)}";
        }

        private static Dictionary<string, string> GetParametersFromReportInfo(ReportInfo fullReportInfo)
        {
            Dictionary<string, string> parameters = fullReportInfo.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => $"{prop.Name}", prop => $"{prop.GetValue(fullReportInfo, null)}");
            return parameters;
        }

        private static string ParseToString(Dictionary<string, string> dictionary)
        {
            string blockReport = string.Empty;
            var items = Enum.GetNames(typeof(ReportItems)).ToList();
            foreach (var item in items)
            {
                string value;
                dictionary.TryGetValue(item, out value);
                if (value != null)
                {
                    blockReport += $@"{item}: {value}{Environment.NewLine}";
                }
            }
            blockReport = RenameTurnToMonth(blockReport);
            return blockReport;
        }

        private static string RenameTurnToMonth(string blockReport)
        {
            return blockReport.Replace("Turn", "Month");
        }

        private static string GetEvents(ReportInfo reportInfo)
        {
            var listEvents = reportInfo.Events;
            return $"Events: {listEvents.Aggregate(string.Empty, (current, item) => current + $@"{Environment.NewLine}{item.EventType}")}";
        }
    }
}
