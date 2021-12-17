﻿using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Xml.Serialization;

namespace EasySave_1_0.model
{
    public class Logger
    {
        static string pathLog = @"..\..\..\Log\";
        public string PathLog
        {
            get
            {
                return pathLog;
            }
        }

        private static Semaphore _poolState = new Semaphore(1, 1);
        private static Semaphore _poolSave = new Semaphore(1, 1);
        
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
                Directory.CreateDirectory(pathLog + @"\Log_XML\");
                Directory.CreateDirectory(pathLog + @"\Log_Json\");
            }
            _poolSave.WaitOne();
            XmlSerializer Xserializer = new XmlSerializer(typeof(ModelLogLog));
            
            var stream = File.AppendText(string.Concat(pathLog, @"\Log_XML\", modelLogLog.Name, @"_log.xml"));
            Xserializer.Serialize(stream, modelLogLog);
            stream.Close();

            string jsonlog = JsonSerializer.Serialize(modelLogLog);
            File.AppendAllText(string.Concat(pathLog, @"\Log_Json\" , modelLogLog.Name, "_log.json"), jsonlog);
            _poolSave.Release();
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
                Directory.CreateDirectory(pathLog + @"\Log_XML\");
                Directory.CreateDirectory(pathLog + @"\Log_Json\");
            }

            _poolState.WaitOne();
            XmlSerializer Xserializer = new XmlSerializer(typeof(List<ModelLogState>));
            
            var stream = File.CreateText(string.Concat(pathLog, @"\Log_XML\", "state.xml"));
            
            Xserializer.Serialize(stream, modelLogState);
            stream.Close();

            string jsonlog = JsonSerializer.Serialize(modelLogState.ToArray());
            File.WriteAllText(string.Concat(pathLog, @"\Log_Json\", "state.json"), jsonlog);
            _poolState.Release();
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
        /// <summary>
        /// transform the exist Save in the log into a save in the app
        /// </summary>
        /// <returns>list of state</returns>
        public List<ModelLogState> JsonToSave()
        {
            try
            {
                string JsonFile = File.ReadAllText(string.Concat(PathLog, @"\Log_Json\", "state.json"));
                return JsonSerializer.Deserialize<List<ModelLogState>>(JsonFile);
            }
            catch
            {
                return new List<ModelLogState>();
            }
        }
    }

}
