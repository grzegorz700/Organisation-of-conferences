using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEF6MainPOApp.Model.ViewModel;

namespace UnitTestProject1.TestsForViewModelSendProposition
{
    class Utils
    {
        public static SendReferatProposiotionViewModel GetCorrectViewModel()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "Jakis dlugi tekst dla abstraktu",
                DateProposition = new DateTime(2016, 3, 12),
                DurationHour = "2",
                DurationMinute = "30",
                PropositionHour = "15",
                PropositionMinute = "10",
                Temat = "Jakis temat"
            };
            return vm;
        }

        public static SendReferatProposiotionViewModel GetCorrectViewModel2()
        {
            SendReferatProposiotionViewModel vm = new SendReferatProposiotionViewModel()
            {
                Abstrakt = "SendReferatProposiotionViewModel to nowa klasa",
                DateProposition = new DateTime(2016, 4, 2),
                DurationHour = "7",
                DurationMinute = "0",
                PropositionHour = "9",
                PropositionMinute = "0",
                Temat = "Jakis temat"
            };
            return vm;
        }
    }
}
