using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.FileStuff
{
    class Logger
    {
        private static readonly string _fileName = @"logs.txt";

        public static void Logging(string logs)
        {
            StreamWriter streamWriter=new StreamWriter(_fileName, true);
            streamWriter.WriteLine(logs);
            streamWriter.WriteLine("------------------");
            streamWriter.Close();
        }
    }
}
