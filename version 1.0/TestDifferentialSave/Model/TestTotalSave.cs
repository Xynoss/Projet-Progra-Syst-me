using EasySave_1_0.model;
using NUnit.Framework;
using System;
using System.IO;


namespace TestEasySave.Model
{

    public class TestTotalSave
    {
        const string sourcePath = "../../../TestPathSource/";
        const string targetPath = "../../../TestPathTarget/";
        const string file = "test.txt";
        const string file2 = "test.pdf";
        const string saveName = "savetest";

        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(sourcePath);
            Directory.CreateDirectory(String.Concat(sourcePath, "dirTest"));
            File.WriteAllText(@String.Concat(sourcePath, file), "Je suis un poisson");
            var stream = File.Create(@String.Concat(sourcePath, file));
            stream.Close();
            var stream2 = File.Create(@String.Concat(sourcePath, file2));
            stream2.Close();

        }

        [Test]
        public void TestTotal()
        {
            ModelSave save = new ModelTotalSave(saveName, sourcePath, targetPath);
            ModelLogState logState = new ModelLogState(saveName, sourcePath, targetPath);
            save.Save(ref logState);
            File.WriteAllText(@String.Concat(sourcePath, "test213.txt"), "texttest<erze");
            save.Save(ref logState);

            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", file)));
            Assert.IsTrue(File.Exists(@String.Concat(targetPath, saveName, "/", file2)));
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
