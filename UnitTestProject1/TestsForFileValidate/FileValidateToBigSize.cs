using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.RawModel;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1.FileValidate
{
    [TestClass]
    public class FileValidateToBigSizeSize
    {
        private static string relafivePath = @"../../Items\";
        private static string fileNameWithOutExtension = "big";
        private static List<string> extensionList = new List<string>();

        [TestMethod]
        public void TestMetodToBigSizeTxt()
        {
            string extension = ".txt";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigSizeDoc()
        {
            string extension = ".doc";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigSizeDocx()
        {
            string extension = ".docx";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigSizePdf()
        {
            string extension = ".pdf";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigSizeDvi()
        {
            string extension = ".dvi";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigSizeDiferentExtension()
        {
            string extension = ".odt";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        private bool UtuilsForValidates(string extension)
        {
            CreateBiggerFile(extension);
            extensionList.Add(extension);
            FileInfo file = new FileInfo(relafivePath + fileNameWithOutExtension + extension);
            System.Diagnostics.Debug.WriteLine(file.FullName);
            return Artykul.FileValidate(file.FullName);
        }

        private void CreateBiggerFile(string extension)
        {
            byte[] file = new byte[2];
            Array.Resize(ref file, 16 * 1024 * 1024 + 1);
            File.WriteAllBytes(relafivePath + fileNameWithOutExtension + extension, file);
        }

        [TestCleanup]
        public void cleanFiles()
        {
            foreach (string extension in extensionList)
            {
                File.Delete(relafivePath + fileNameWithOutExtension + extension);
            }
            extensionList.Clear();
        }

    }

}
