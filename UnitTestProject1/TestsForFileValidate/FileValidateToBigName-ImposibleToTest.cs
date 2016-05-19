using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.RawModel;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1.FileValidate
{

    //Z ograniczen niezaleznych nie jest mozliwe przetestowanie tej funkcjonalnosci przy zrownaniu sie z gorna granica jest blad pomimo iż komunikat bledu blibioleki standardowej sugeruje ze powinno byc jescze dobrze

    /*
    [TestClass]
    public class FileValidateToBigName
    {
        private static string relafivePath  = @"D:\";
        private static string fileNameWithOutExtension = new string('c',252); // 4znaki to rozszerzenie
        private static List<string> extensionList = new List<string>();

        //[TestMethod]
        public void TestMethod1()
        {
            FileInfo file = new FileInfo(@"../../Items\1KB.txt");
            System.Diagnostics.Debug.WriteLine(file.FullName);
            foreach (string fileName in Directory.EnumerateFiles(relafivePath, "*", SearchOption.AllDirectories))
            {
                System.Diagnostics.Debug.WriteLine(fileName);
            }
            //Directory.EnumerateFiles();
            Artykul.FileValidate(@"C:\Users\Grzegorz\Desktop\potest\cos.txt");
        }

        [TestMethod]
        public void TestMetodToBigNameTxt()
        {
            string extension = ".txt";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigNameDoc()
        {
            string extension = ".doc";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        //[TestMethod]
        public void TestMetodToBigNameDocx()
        {
            string extension = ".docx";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigNamePdf()
        {
            string extension = ".pdf";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigNameDvi()
        {
            string extension = ".dvi";
            Assert.IsFalse(UtuilsForValidates(extension));
        }

        [TestMethod]
        public void TestMetodToBigNameDiferentExtension()
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
            Array.Resize(ref file, 2 * 1024 * 1024 + 1);
            var fileName = fileNameWithOutExtension + extension;
            Assert.IsTrue(fileName.Length < 260);
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
    */
}
