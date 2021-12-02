using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;

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
            if (!Directory.Exists(pathLog))
            {
                Directory.CreateDirectory(pathLog);
            }
            string jsonlog = JsonSerializer.Serialize(modelLogLog);
            string xml_log = "";
            XmlSerializer serializer = new XmlSerializer(typeof(ModelLogLog));
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, modelLogLog);
                    xml_log = sww.ToString(); // Your XML
                }
            }
            File.AppendAllText(string.Concat(pathLog, modelLogLog.Name, "_log.json"), jsonlog);
            File.AppendAllText(string.Concat(pathLog, modelLogLog.Name, "_log.xml"), xml_log);
        }
        /// <summary>
        /// Method to write a state file.
        /// </summary>
        /// <param name="modelLogState">State object to write a log file</param>
        public void WriteState(List<ModelLogState> modelLogState)
        {
            if (!Directory.Exists(pathLog))
            {
                Directory.CreateDirectory(pathLog);
            }
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
