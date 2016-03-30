using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.ParsingStuff
{
    class Parser
    {
        public static string[] ParsedLogs(ReportInfo fullReportInfo)
        {

            var parameters = fullReportInfo.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(fullReportInfo, null));
            string[] parametersAfterInverse =
                parameters.Select(parameter => $"{parameter.Key}: {parameter.Value}").ToArray();

            parametersAfterInverse = ChangedParameters(parametersAfterInverse);

            return parametersAfterInverse;
        }

        private static string[] ChangedParameters(string[] parameters)
        {
            string turn = parameters[9];
            string month = turn.Replace("Turn", "Month");
            parameters[9] = month;
            var aux = parameters[9];
            parameters[9] = parameters[0];
            parameters[0] = aux;
            aux = parameters[9];
            parameters[9] = parameters[4];
            parameters[4] = aux;
            aux = parameters[12];
            parameters[12] = parameters[2];
            parameters[2] = aux;
            aux = parameters[11];
            parameters[11] = parameters[3];
            parameters[3] = aux;
            aux = parameters[6];
            parameters[6] = parameters[1];
            parameters[1] = aux;
            aux = parameters[13];
            parameters[13] = parameters[5];
            parameters[5] = aux;
            aux = parameters[14];
            parameters[14] = parameters[6];
            parameters[6] = aux;
            aux = parameters[14];
            parameters[14] = parameters[7];
            parameters[7] = aux;
            aux = parameters[12];
            parameters[12] = parameters[8];
            parameters[8] = aux;
            aux = parameters[11];
            parameters[11] = parameters[9];
            parameters[9] = aux;
            aux = parameters[11];
            parameters[11] = parameters[10];
            parameters[10] = aux;
            aux = parameters[13];
            parameters[13] = parameters[11];
            parameters[11] = aux;
            aux = parameters[14];
            parameters[14] = parameters[1];
            parameters[1] = aux;
            return parameters;

        }


    }
}
