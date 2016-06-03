using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Main
{
    public class LogSystem
    {
        private readonly string _logFileName;

        public LogSystem(string logFileName = "log.txt")
        {
            _logFileName = logFileName;

            var fs = File.Create(_logFileName);
            fs.Close();
        }

        public void Write(string msg)
        {
            StreamWriter sw = File.AppendText(_logFileName);
            try
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}: {msg}");
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
