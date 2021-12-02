using EasySave_1_0.model;
using NUnit.Framework;
using System;
using System.IO;

namespace TestEasySave
{
    public class TestDifferentialSave
    {
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
            ModelSave saveComplete = new ModelTotalSave(saveCompleteName, sourcePath, targetPath);
            ModelLogState stateComplete = new ModelLogState(saveCompleteName, sourcePath, targetPath);
            saveComplete.Save(ref stateComplete);
            File.WriteAllText(@String.Concat(sourcePath, file), "Je suis une patate");
            var streamAdd = File.Create(@String.Concat(sourcePath, fileAdd));
            streamAdd.Close();
        }

        [Test]
        public void TestDifferential()
        {
            ModelSave save = new ModelDifferentialSave(saveName, sourcePath, targetPath, @String.Concat(targetPath, saveCompleteName, "/"));
            ModelLogState logState = new ModelLogState(saveName, sourcePath, targetPath);
            save.Save(ref logState);

            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", file)));
            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", fileAdd)));
            Assert.IsFalse(File.Exists(@String.Concat(targetPath, saveName, "/", fileNoneModif)));
        }

        [Test]
        public void TestDifferentialx2()
        {
            ModelSave save = new ModelDifferentialSave(saveName, sourcePath, targetPath, @String.Concat(targetPath, saveCompleteName, "/"));
            ModelLogState logState = new ModelLogState(saveName, sourcePath, targetPath);
            save.Save(ref logState);
            Directory.CreateDirectory(@String.Concat(sourcePath, "DirTest"));
            var stream = File.Create(@String.Concat(sourcePath, "test2.txt"));
            stream.Close();
            save.Save(ref logState);

            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", file)));
            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", "test2.txt")));
            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", fileAdd)));
            Assert.IsFalse(File.Exists(@String.Concat(targetPath, saveName, "/", fileNoneModif)));
            Assert.IsTrue(Directory.Exists(@String.Concat(targetPath, saveName, "/", "DirTest")));
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