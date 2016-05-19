using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfEF6MainPOApp.Model.RawModel;

namespace WpfEF6MainPOApp.Model.ViewModel
{
    /// <summary>
    /// Klasa view modelu dla Wybierania referatu (w celu wysłania do niego póżniej artykułu).
    /// </summary>
    public class SelectionReferatViewModel : ViewModel
    {

        private List<Referat> referatry;
        public List<string> ListaTematowReferafow { get; private set; }             
        private Referat actReferat;
        public Referat ActualReferat
        {
            get
            {
                return actReferat;
            }
            set
            {
                if (value != null)
                {
                    actReferat = value;
                    Abstrakt = ActualReferat.Abstrakt;
                    Data = ActualReferat.DataRozpoczecia != null ? ActualReferat.DataRozpoczecia.ToShortDateString() : "Brak daty";
                    using (var context = new KonfContext())
                    {
                        var sala = ActualReferat.SalaID.HasValue ? context.Sale.First(s => s.ID == ActualReferat.SalaID.Value) : null;
                        Sala = sala != null ? sala.Nazwa : "Brak ustalonej sali";
                    }
                    
                    updatePrelegenci();
                    NotifyPropertyChange("Abstrakt");
                    NotifyPropertyChange("Data");
                    NotifyPropertyChange("Sala");
                }
            }
        }      
        public string Abstrakt { get; set; }
        public string Prelegenci { get; set; }
        public string Data { get; set; }
        public string Sala { get; set;}
        
        /// <summary>
        /// Konstruktor view modelu dla Wybierania referatu (w celu wysłania do niego póżniej artykułu).
        /// </summary>
        public SelectionReferatViewModel()
        {
            using (var context = new KonfContext())
            {
                var actPrelegent = context.Prelegenci.First(p => p.ID == UserSession.ActualPrelegent.ID);
                referatry = actPrelegent.referat.ToList();
            }            
            ListaTematowReferafow = referatry.Select(r => r.Tytul).ToList();
        }

        /// <summary>
        /// Ustawienie referatu na wybrany z listy o podammym indexie
        /// </summary>
        /// <param name="index"></param>
        public void  setActualReferat(int index){
            ActualReferat = referatry[index];
        }

        private void updatePrelegenci()
        {
            IEnumerable<string> prelegenciTable;
            using (var context = new KonfContext())
            {
                context.Referaty. Attach(actReferat);
                prelegenciTable = actReferat.prelegent.Select(p => p.TytulNaukowy + " " + p.Nazwisko + " " + p.Imie);
            }
            
            StringBuilder wynik = new StringBuilder();
            foreach(var actTablePrelegent in prelegenciTable){
                wynik.Append(actTablePrelegent + ", ");
            }
            wynik.Remove(wynik.Length-2,1);
            Prelegenci = wynik.ToString();
            NotifyPropertyChange("Prelegenci");
        }

        /// <summary>
        /// Metoda sprawdzająca czy jest możliwość wyboru referatu, a tym samym możliwośc zmiany widoku na ten obsługiwany przez ten ViewModel
        /// </summary>
        /// <returns></returns>
        public static bool IsPosibleToChangeviewToThis()
        {
            using (var context = new KonfContext())
            {
                Prelegent actPerson = context.Prelegenci.First(p => p.ID == UserSession.ActualPrelegent.ID);
                return actPerson.referat.Count() != 0;
            }
        }
    }
}
