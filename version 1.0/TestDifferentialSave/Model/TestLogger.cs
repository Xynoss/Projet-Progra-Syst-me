using EasySave_1_0.model;
using NUnit.Framework;
using System;
using System.IO;
using System.Text.Json;

namespace TestEasySave.Model
{
    public class TestLogger
    {
        const string pathlog = @"..\..\..\..\..\Log\";
        const string sourcePath = "../../../TestPathSource/";
        const string targetPath = "../../../TestPathTarget/";
        const string fileNoneModif = "testNoModif.txt";
        const string file = "test.txt";
        const string fileAdd = "Bonsoir.txt";
        const string saveName = "savetest";
        const string saveCompleteName = "savereftest";


        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(sourcePath);
            File.WriteAllText(@String.Concat(sourcePath, fileNoneModif), "Je suis un poisson");
            var stream = File.Create(@String.Concat(sourcePath, file));
            stream.Close();
        }

        [Test]
        public void TestLog()
        {
            ModelSave saveComplete = new ModelTotalSave(saveCompleteName, sourcePath, targetPath);
            ModelLogState stateComplete = new ModelLogState(saveCompleteName, sourcePath, targetPath);
            saveComplete.Save(ref stateComplete);
            string log_path_complete = @String.Concat(pathlog, saveName, "_log.json");
            string state_path_complete = @String.Concat(pathlog, "state.json");
            Assert.IsTrue(File.Exists(log_path_complete));
            Assert.IsTrue(File.Exists(state_path_complete));

        }


        [TearDown]
        public void EndTest()
        {
            try
            {

            }
            catch { }
            try
            {
            }
            catch { }
        }
    }
}
