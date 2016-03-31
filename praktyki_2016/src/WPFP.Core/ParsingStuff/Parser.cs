using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.ParsingStuff
{
    public class Parser
    {
        public static string ParseToString(ReportInfo fullReportInfo)
        {
            var parameters = GetParametersFromReportInfo(fullReportInfo);
            return ParseFromDictionaryToString(parameters);
        }

        private static Dictionary<string, object> GetParametersFromReportInfo(ReportInfo fullReportInfo)
        {
            Dictionary<string, object> parameters = fullReportInfo.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(fullReportInfo, null));
            return parameters;
        }

        private static string ParseFromDictionaryToString(Dictionary<string, object> dictionary)
        {
            List<string> items = Enum.GetNames(typeof(ReportItems)).ToList();
            string reportBlock = ConvertToString(dictionary, items);
            reportBlock = RenameTurnToMonth(reportBlock);
            return reportBlock;
        }

        private static string ConvertToString(Dictionary<string, object> dictionary, List<string> items)
        {
            string reportBlock = String.Empty;
            foreach (var item in items)
            {
                var value = dictionary.Where(x => x.Key.Equals(item)).Select(x => x.Value).FirstOrDefault();
                if (value == null) continue;
                if (value.GetType().IsGenericType)
                {
                    var enumerable = value as IEnumerable;
                    if (enumerable == null) continue;
                    reportBlock = enumerable.Cast<object>().Aggregate(reportBlock, (current, v) => current + WriteToNewLine(item, v));
                }
                else
                {
                    reportBlock += WriteToNewLine(item, value);
                }
            }
            return reportBlock;
        }

        private static string WriteToNewLine(string item, object value)
        {
            return $@"{item}: {value}{Environment.NewLine}";
        }

        private static string RenameTurnToMonth(string blockReport)
        {
            return blockReport.Replace("Turn", "Month");
        }
    }
}
