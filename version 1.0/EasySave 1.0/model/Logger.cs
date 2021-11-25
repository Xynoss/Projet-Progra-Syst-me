using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EasySave_1_0.model
{
    public class Logger
    {
        static string pathLog = @"..\..\..\..\..\Log\";
        static Logger _instance;
        private Logger()
        {
        }
        /// <summary>
        /// Method to write a log file.
        /// </summary>
        /// <param ModelLogLog="modelLogLog">Log object to write a log file</param>
        public void WriteLog(ModelLogLog modelLogLog)
        {
            string jsonlog = JsonSerializer.Serialize(modelLogLog);
            File.AppendAllText(string.Concat(pathLog, modelLogLog.Name, "_log.json"), jsonlog);
        }
        /// <summary>
        /// Method to write a state file.
        /// </summary>
        /// <param name="modelLogState">State object to write a log file</param>
        public void WriteState(List<ModelLogState> modelLogState)
        {
            string jsonlog = JsonSerializer.Serialize(modelLogState.ToArray());
            File.WriteAllText(string.Concat(pathLog, "state.json"), jsonlog);
        }
        /// <summary>
        /// Method to return a existed instance or create a new one. (SINGLETON)
        /// </summary>
        /// <returns>instance of the class.</returns>
        static public Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
    }
    
}
