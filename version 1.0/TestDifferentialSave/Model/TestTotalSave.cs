using EasySave_1_0.Controller;
using EasySave_1_0.model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;


namespace TestEasySave.Model
{

    public class TestTotalSave
    {
        const string sourcePath = "../../../TestPathSource/";
        const string targetPath = "../../../TestPathTarget/";
        const string file = "test.txt";
        const string saveName = "savetest";

        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(sourcePath);
            Directory.CreateDirectory(String.Concat(sourcePath, "dirTest"));
            File.WriteAllText(@String.Concat(sourcePath, file), "Je suis un poisson");
            var stream = File.Create(@String.Concat(sourcePath, file));
            stream.Close();

        }

        [Test]
        public void TestTotal()
        {
            ModelSave save = new ModelTotalSave(saveName, sourcePath, targetPath);
            ModelLogState logState = new ModelLogState(saveName, sourcePath, targetPath, "savetype");
            List<ModelLogState> fullListStates = Controller.States;
            save.Save(ref logState , ref fullListStates);
            File.WriteAllText(@String.Concat(sourcePath, "test213.txt"), "texttest<erze");
            save.Save(ref logState, ref fullListStates);

            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", file)));
            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", "test213.txt")));
            Assert.IsTrue(Directory.Exists(@String.Concat(targetPath, saveName, "/", "dirTest")));
        }

        [TearDown]
        public void EndTest()
        {
            try
            {
                Directory.Delete(targetPath, true);
            }
            catch { }
            try
            {
                Directory.Delete(sourcePath, true);
            }
            catch { }
        }
    }
}
