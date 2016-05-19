using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.Model.RawModel;
using System.Collections.Generic;

namespace UnitTestProject1.TestsForViewModelSendProposition
{
    [TestClass]
    public class TestsToCrash
    {
        private static List<string> wyrazy = new List<string>()
        {
            "Siała", "baba", "mak", "nie", "wiedziała", "jak", "a", "dziad", "wiedział", "a", "to", "było", "tak."
        };

        [TestMethod]
        public void VMSendPropositionTestsToCrashAbstrakt()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashAbstraktToLong()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = new String('B', 2049),
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashDurationHour()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "-2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashDurationMinute()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "3o",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashPropositionHour()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "25",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashPropositionMinute()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "1o",
                Temat = "Jakis temat"
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashTemat()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = ""
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }

        [TestMethod]
        public void VMSendPropositionTestsToCrashPropositionTematToLong()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = new String('A',101)
            };
            string error;
            Referat referat = vm.TryGetReferat(out error);
            commonAssertions(vm, referat, error);
        }


        private void commonAssertions(SendReferatProposiotionViewModel vm, Referat referat, string error)
        {
            Assert.IsNull(referat);
            Assert.IsTrue(error != null && error.Length >  0);
        }


    }
}
