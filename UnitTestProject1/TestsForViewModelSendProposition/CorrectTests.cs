using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.Model.RawModel;
using System.Collections.Generic;

namespace UnitTestProject1.TestsForViewModelSendProposition
{
    //Testy powinny byc powtarzalne dlatogo uzyto stałych danych, przedstawiono kilka przykladow ktore powinny dac wynik pozutywny. Kazdy z nich podaje inny zestaw danych.

    [TestClass]
    public class CorrectTests
    {
        private static List<string> wyrazy = new List<string>()
        {
            "Siała", "baba", "mak", "nie", "wiedziała", "jak", "a", "dziad", "wiedział", "a", "to", "było", "tak."
        };


        [TestMethod]
        public void VMSendPropositionCorrect1()
        {
            SendReferatProposiotionViewModel vm = Utils.GetCorrectViewModel();
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionCorrect2()
        {
            SendReferatProposiotionViewModel vm = Utils.GetCorrectViewModel();
            vm.Temat = "B" +  new String('a', 10) + " " + new String('b', 8) + ".";
            vm.Abstrakt = "To" + new String('c', 10) + " " + new String('e', 8) + "." +
                "To" + new String('c', 10) + " " + new String('e', 8) + ".";
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }


        [TestMethod]
        public void VMSendPropositionCorrect3()
        {
            SendReferatProposiotionViewModel vm = Utils.GetCorrectViewModel2(); //Second model
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionCorrect4()
        {
            SendReferatProposiotionViewModel vm = Utils.GetCorrectViewModel2(); //Second model
            var temat = "";
            for (int i = 0; i < 4; i++)
            {
                temat += wyrazy[i];
            }
            vm.Temat = temat;
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionCorrect5()
        {
            SendReferatProposiotionViewModel vm = Utils.GetCorrectViewModel2(); //Second model
            var abstakt = "";
            for (int i = 0; i < wyrazy.Count; i++)
            {
                abstakt += wyrazy[i];
            }
            vm.Abstrakt = abstakt;
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }


        private void commonAssertions(SendReferatProposiotionViewModel vm, Referat referat, string error)
        {
            Assert.IsNotNull(referat);
            Assert.IsTrue(error == null || error.Length == 0);
            Assert.AreEqual(referat.Abstrakt, vm.Abstrakt);
            Assert.AreEqual(referat.Tytul, vm.Temat);
            Assert.AreEqual(referat.CzyZaakceptowany, StatusReferatu.Zloszony);
            Assert.AreEqual(referat.DataRozpoczecia.Year, vm.DateProposition.Year);
            Assert.AreEqual(referat.DataRozpoczecia.Month, vm.DateProposition.Month);
            Assert.AreEqual(referat.DataRozpoczecia.Day, vm.DateProposition.Day);
            Assert.IsTrue(referat.DataRozpoczecia.Hour == Int32.Parse(vm.PropositionHour));
            Assert.IsTrue(referat.DataRozpoczecia.Minute == Int32.Parse(vm.PropositionMinute));
        }


    }
}
