using System;
using System.Collections.Generic;
using WPFP.CommunicationLayer.DTO;
using WPFP.CommunicationLayer.Interfaces;
using WPFP.Core.FileStuff;
using WPFP.Core.ParsingStuff;
using WPFP.Core.ScoringItems;
using WPFP.Psyche;
using WPFP.Psyche.StateMachine;
using WPFP.SimConfiguration.Dependency;

namespace WPFP.Core
{
    public class SimpleCore : ISimpleCore
    {
        private readonly SimulationSubject _simulationSubject;

        public SimpleCore()
        {
            // Do not touch this.
            // This works and it is awesome.
            DependencyContainer.RegisterDependencies();
            _simulationSubject = DependencyContainer.Resolve<SimulationSubject>();
        }

        public ISimpleView Form { get; set; }

        public void DisplayStartInfo()
        {
            ReportInfo fullReportInfo = _simulationSubject.GetCurrentStateOfSimulation();
            string formattedStateResponse = FormatStateResponse(fullReportInfo);
            Form.DisplayOnUi(formattedStateResponse);
        }

        public void PerformAction(string text)
        {
            PerformActionOnSubject(text);
        }

        public void PerformMacroFromFile(string fileName)
        {
            // To do 1: Read From File.
            string [] actions= FileLoader.LoadFileActions(fileName);
            IEnumerable<string> fileLines = actions;
            string report=string.Empty;
            ScoringWriter scoringWriter=new ScoringWriter();
            foreach (var line in fileLines)
            {
                PerformActionOnSubject(line);

                ReportInfo fullReportInfo = _simulationSubject.GetCurrentStateOfSimulation();
                scoringWriter.WriteParameters(fullReportInfo);
                report += PrepareReport(fullReportInfo);

            }
            Logger.Logging(report);
            // To do 2: Save formated information to file.

        }

        private static string PrepareReport(ReportInfo fullReportInfo)
        {
            string separator = "----------------------";
            return string.Format("{0} {1} {2} {3}", Parser.ParseToString(fullReportInfo), Environment.NewLine , separator, Environment.NewLine);
        }

        private void PerformActionOnSubject(string line)
        {
            try
            { 
                _simulationSubject.PerformAction(line);
                ReportInfo fullReportInfo = _simulationSubject.GetCurrentStateOfSimulation();
                var formattedStateResponse = FormatStateResponse(fullReportInfo);
                Form.DisplayOnUi(formattedStateResponse);
            }
            catch (InvalidOperationException)
            {
                Form.DisplayOnUi(string.Format("Error in line:\" {0}\". Operation is not supported.", line));
            }
        }

        private string FormatStateResponse(ReportInfo fullReportInfo)
        {
            string report = Parser.ParseToString(fullReportInfo);
            string formattedStateResponse = $"{Environment.NewLine} {report} {Environment.NewLine}";
            return formattedStateResponse;
        }
    }
}
