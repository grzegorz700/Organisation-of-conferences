using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEF6MainPOApp.Model.RawModel;

namespace WpfEF6MainPOApp.Model.ViewModel
{
    /// <summary>
    /// Klasa view modelu dla Wystłania propozysji referatu.
    /// </summary>
    public class SendReferatProposiotionViewModel 
    {
        public string Temat { get; set; }
        public string Abstrakt { get; set; }
        public DateTime DateProposition { get; set; }
        public string PropositionHour { get; set; }
        public string PropositionMinute { get; set; }
        public string DurationHour { get; set; }
        public string DurationMinute { get; set; }

        /// <summary>
        /// Konstruktor view modelu dla Wystłania propozysji referatu.
        /// </summary>
        public SendReferatProposiotionViewModel()
        {
            Temat = "";
            Abstrakt = "";
            PropositionHour = "16";
            PropositionMinute = "20";
            DurationHour = "2";
            DurationMinute = "10";
            DateProposition = DateTime.Now;
        }

        /// <summary>
        /// Metoda odpowiedzialna za przyjęcie zgłoszenia referatu. Przyjmuje referat, jeśli nie pojawiły się jakieś błędy.
        /// </summary>
        /// <param name="errors"> Wynik ->Bledy zawarte w viewmodelu uniemożliwiające zaproponowanie referatu </param>
        /// <returns> True - jeśli wysłano propozyję referet, albo null jeśli pojawiły się błędy</returns>
        public bool sendProposition(out string errors)
        {
            errors = "";
            var referat  = TryGetReferat(out errors);

            if (errors != null && errors.Length > 0)
            {
                return false;
            }
            else
            {                
                var konf = UserSession.ActualKonferencja;
                var prelegent = UserSession.ActualPrelegent;
                using(var context = new KonfContext())
                {
                    referat.ID = context.Referaty.Count()+1;
                    context.Konferencje.Attach(konf);
                    context.Prelegenci.Attach(prelegent);

                    referat.konferencja = konf;
                    referat.prelegent.Add(prelegent);

                    context.Referaty.Add(referat);
           
                    context.SaveChanges();
                }
            }
            return true;
        }

        /// <summary>
        /// Metoda próbująca stworzyć Referat z aktualnie zapisanych danych w ViewModelu
        /// </summary>
        /// <param name="errorMessage"> Wynik ->Bledy zawarte w viewmodelu uniemożliwiające stworzenie Referatu </param>
        /// <returns> Utorzony referet, albo null jeśli pojawiły się błędy</returns>
        public Referat TryGetReferat(out string errorMessage)
        {
            errorMessage = "";
            string errorFromTytulAbstrakt;
            string errorFromDateProposiotion;
            string errorFromDuration;
            DateTime? date = TryGetDateProposition(out errorFromDateProposiotion);
            TimeSpan? time = TryGetDuration(out errorFromDuration);
            ValidateTytulAbstrakt(out errorFromTytulAbstrakt);

            if (errorFromDateProposiotion.Length > 0 ||
                errorFromDuration.Length > 0 || 
                errorFromTytulAbstrakt.Length > 0)
            {
                errorMessage = errorFromTytulAbstrakt + errorFromDateProposiotion + errorFromDuration;
                return null;
            }
            else
            {
                var dataRozpoczecia = date.Value;
                var duration = time.Value;
                var dataZakonczenia = dataRozpoczecia.AddHours(duration.Hours).AddMinutes(duration.Minutes);
                var referat = new Referat()
                {
                    Abstrakt = this.Abstrakt,
                    Tytul = this.Temat,
                    CzyZaakceptowany = StatusReferatu.Zloszony,
                    DataRozpoczecia = dataRozpoczecia,
                    DataZakonczenia = dataZakonczenia,
                };
                return referat;
            }
        }

        private bool ValidateTytulAbstrakt(out string errorMessage)
        {
            errorMessage = "";
            if (Temat == null || Temat.Length < 3 || Temat.Length > 100 )
            {
                errorMessage += "Podaj tytul (składający się z od 3  do 100 znaków).\n";
                
            }
            if(Abstrakt == null || Abstrakt.Length < 10 || Abstrakt.Length > 2048)
            {
                errorMessage += "Podaj abstrakt (składa się od 10  do 2048 znaków).\n";
            }
            return errorMessage.Length == 0;
        }

        private DateTime? TryGetDateProposition(out string errorMessage)
        {
            errorMessage = "";

            int hour = 0;
            int minute = 0;
            bool timeCorrect = int.TryParse(PropositionMinute, out minute) &&
                int.TryParse(PropositionHour, out hour);
            if (!timeCorrect)
            {
                errorMessage += "Nie poprawny czas prelekcji tylko cyfry\n";
            }
            else if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            {
                errorMessage += "Nie poprawna godzina prelekcji\n";
            }

            if (DateProposition == null)
            {
                errorMessage += "Nie wybrano daty";
            }


            if (errorMessage.Length > 0)
            {
                return null;
            }
            else
            {
                DateTime result = new DateTime(DateProposition.Year, DateProposition.Month, DateProposition.Day, hour, minute, 0);
                return result;
            }
        }

        private TimeSpan? TryGetDuration(out string errorMessage)
        {
            errorMessage = "";
            int hour = 0;
            int minute = 0;
            bool timeCorrect = int.TryParse(DurationMinute, out minute) &&
                int.TryParse(DurationHour, out hour);

            if (!timeCorrect)
            {
                errorMessage += "Nie poprawny czas trwania - powinny być tylko cyfry\n";
                
            }
            else if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            {
                errorMessage += "Nie poprawny czas trwania prelekcji (minimalny czas 0h 0 min, max 23h59min\n";
            }

            if (errorMessage.Length > 0)
            {
                return null;
            }
            else
            {
                return new TimeSpan(hour, minute, 0);
            }
        }

    }
}
