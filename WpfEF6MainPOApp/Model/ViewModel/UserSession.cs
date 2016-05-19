using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEF6MainPOApp.Model.RawModel;

namespace WpfEF6MainPOApp.Model.ViewModel
{
    /// <summary>
    /// Klasa składująca dane o aktualnie zalogowanym uczestniku i aktualnej konferencji
    /// </summary>
    public class UserSession
    {
        private static Prelegent prelegent;
        private static Konferencja konferencja;

        /// <summary>
        /// Własnosc składująca dane o aktualnie zalogowanym uczestniku
        /// </summary>
        public static Prelegent ActualPrelegent {
            get
            {
                if (prelegent == null)
                {
                    return null;
                }
                else
                {
                    using (var context = new KonfContext())
                    {
                        return context.Prelegenci.First(p => p.ID == prelegent.ID);
                    }  
                }
            }
            set
            {
                prelegent = value;
            }
        }

        /// <summary>
        /// Własnosc udostepniająca pełne imię i nazwisko aktualnie zalogowanego uczestnika
        /// </summary>
        public static string FullName { 
            get 
            {
                Prelegent prelegent = ActualPrelegent;
                return prelegent == null ? "Brak plelegenta" : (ActualPrelegent.Imie + " " + ActualPrelegent.Nazwisko);
            }
        }

        /// <summary>
        /// Własność składująca dane o aktualnej konferencji
        /// </summary>
        public static Konferencja ActualKonferencja
        {
            get
            {
                if (konferencja == null)
                {
                    return null;
                }
                else
                {
                    using (var context = new KonfContext())
                    {
                        return context.Konferencje.First(k => k.ID == konferencja.ID);
                    }
                }
            }

            set
            {
                konferencja = value;
            }
        }

        
       //public static bool RefreshData()
       //{
       //    if (ActualPrelegent != null)
       //    {
       //        using (var context = new KonfContext())
       //        {
       //            ActualPrelegent = context.Prelegenci.First(p => p.ID == ActualPrelegent.ID);
       //        }
       //    }
       //    else
       //    {
       //        return false;
       //    }
       //    return true;
       //}
    }
}
