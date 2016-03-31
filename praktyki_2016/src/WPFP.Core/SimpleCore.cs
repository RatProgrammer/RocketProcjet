using System;
using System.Collections.Generic;
using WPFP.CommunicationLayer.DTO;
using WPFP.CommunicationLayer.Interfaces;
using WPFP.Core.FileStuff;
using WPFP.Core.ParsingStuff;
using WPFP.Psyche;
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
            foreach (var line in fileLines)
            {
                PerformActionOnSubject(line);

                ReportInfo fullReportInfo = _simulationSubject.GetCurrentStateOfSimulation();
                string report =Parser.ParseToString(fullReportInfo);
                Logger.Logging(report);
            }

            // To do 2: Save formated information to file.

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
