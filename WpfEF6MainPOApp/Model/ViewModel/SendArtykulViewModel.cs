using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEF6MainPOApp.Model.RawModel;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace WpfEF6MainPOApp.Model.ViewModel
{
    /// <summary>
    /// Klasa view modelu dla Wystłania artykułu dla wybranego referatu.
    /// </summary>
    public class SendArtykulViewModel : ViewModel
    {      
        private Referat referat;
        public string Temat { get; set; }
        public string Abstrakt { get; set; }
        public string Prelegenci { get; set; }
        public string DeadlineArtykulu { get; set; }
        public string DeadlinePoprawki { get; set; }
        public string PlikArtukulu { get; set; }
        public string DataWyslaniaPlikuArtukulu { get; set; }
        public string PlikPoprawki { get; set; }
        public string DataWyslaniaPlikuPoprawki { get; set; }
        private static string fileFilter = 
                "Text files (*.txt)|*.txt|" +
                "Text files (*.doc)|*.doc|" +
                "Text files (*.docx)|*.docx|" +
                "Portable Document Format (*.pdf)|*.pdf|" +
                "Latex File (*.dvi)|*.dvi";

        /// <summary>
        /// Konstruktor view modelu dla Wystłania artykułu dla wybranego referatu.
        /// </summary>
        /// <param name="referat">wybrany referat dla którego chcemy wysłać artykuł</param>
        public SendArtykulViewModel(Referat referat)
        {
            if (referat == null)
            {
                throw new ArgumentNullException();
            }
            this.referat = referat;
            updatePrelegenci();
            Temat = referat.Tytul;
            Abstrakt = referat.Abstrakt;

            using (var context = new KonfContext())
            {
                context.Referaty.Attach(referat);
                DeadlineArtykulu = referat.konferencja.DeadlineZglaszaniaArtykulu.ToString("dd.MM.yyyy    HH:MM");
                PlikArtukulu = referat.artykul1 == null ? "Brak pliku" : referat.artykul1.NazwaPliku;
                DataWyslaniaPlikuArtukulu = referat.artykul1 == null ? "" : referat.artykul1.DataWyslania.ToString() ;
                DeadlinePoprawki = referat.konferencja.DeadlineOstatecznyArtykulu.ToString("dd.MM.yyyy    HH:MM");
                PlikPoprawki = referat.artykul2 == null ? "Brak pliku" : referat.artykul2.NazwaPliku;
                DataWyslaniaPlikuPoprawki = referat.artykul2 == null ? "" : referat.artykul2.DataWyslania.ToString();
            }
        }

        /// <summary>
        /// Metoda zwracająca filtry do obiektu OpenFileDialog
        /// </summary>
        public static string FileFilter
        {
            get{ return fileFilter;}   
        }

        /// <summary>
        /// Metoda służąca do wysłania i zapisania artykułu dla referatu wybranego dla viewmodelu.
        /// </summary>
        /// <param name="fileDialog"> obiekt z którego wybrano plik do wysłania</param>
        /// <returns></returns>
        public bool sendingFile(OpenFileDialog fileDialog)
        {
            if (!Artykul.FileValidate(fileDialog.FileName))
                return false;
            byte[] fileInBytes = File.ReadAllBytes(fileDialog.FileName);

            System.Diagnostics.Debug.WriteLine("@MY@@@@  " + fileDialog.FileName + "@My@");
            System.Diagnostics.Debug.WriteLine("@MY@@@@  " + fileInBytes.Length + "@My@");
            var fileName = getFileNameFromPath(fileDialog.FileName);

            Action<byte[], string> action;
            var result = validateSending(out action);
            if (!result)
            {
                return false;
            }
            else
            {
                action(fileInBytes, fileName);
            }
            //Testowe
            //var fileFromDB = context.Artykuly.First(a => a.ID == file.ID);
            //testReadFromDBAndSave(fileFromDB);

            NotifyPropertyChange("PlikArtukulu");
            NotifyPropertyChange("DataWyslaniaPlikuArtukulu");
            NotifyPropertyChange("PlikPoprawki");
            NotifyPropertyChange("DataWyslaniaPlikuPoprawki");
            //System.Diagnostics.Debug.WriteLine("@MY@@@@  " + "Zapisano jego id to " + file.ID + "@My@");

            return true;
        }


        private void podepnijArtykul(KonfContext context, Artykul file)
        {
            referat.artykul1 = file;
        }

        private void testReadFromDBAndSave(Artykul fileFromDB)
        {
            File.WriteAllBytes(@"C:\Users\Grzegorz\Desktop\potest\" + fileFromDB.NazwaPliku, fileFromDB.Plik);
            System.Diagnostics.Debug.WriteLine("@MY@@@@  " + "Wybrany plik ma ilośc bajtow = " + fileFromDB.Plik.Length + "@My@");
        }

        private string getFileNameFromPath(string fullpath)
        {
            return fullpath.Substring(fullpath.LastIndexOf('\\')+1);
        }

        private void updatePrelegenci()
        {
            IEnumerable<string> prelegenciTable;
            using (var context = new KonfContext())
            {
                context.Referaty.Attach(referat);
                prelegenciTable = referat.prelegent.Select(p => p.TytulNaukowy + " " + p.Nazwisko + " " + p.Imie);
            }

            StringBuilder wynik = new StringBuilder();
            foreach (var actTablePrelegent in prelegenciTable)
            {
                wynik.Append(actTablePrelegent + ", ");
            }
            wynik.Remove(wynik.Length - 2, 1);
            Prelegenci = wynik.ToString();
            NotifyPropertyChange("Prelegenci");
        }

        private bool validateSending(out Action<byte[],string> action)
        {
            action = null;
            using (var context = new KonfContext())
            {
                context.Referaty.Attach(referat);
                var konferencja = referat.konferencja;
                if (konferencja.DeadlineZglaszaniaArtykulu < DateTime.Now)
                {
                    if ((referat.CzyZaakceptowany == StatusReferatu.Zaakceptowany || referat.CzyZaakceptowany == StatusReferatu.NieZaakceptowany)
                        || konferencja.DeadlineOstatecznyArtykulu < DateTime.Now)
                    {
                        return false;
                    }
                    else
                    {
                        if (referat.artykul1 != null && referat.artykul2 != null)
                        {
                            //Umozliwienie aktualizacji 2 artykułu
                            action = DBArticleUpdate;
                        }
                        else
                        {
                            //Umozliwienie dodania 2 artykułu
                            action = DBArticleSave;
                        }
                    }
                }
                else
                {
                    if (referat.artykul1 != null)
                    {
                        //Umozliw aktualizacje 1 artukułu
                        action = DBArticleUpdate;
                    }
                    else
                    {
                        //Umozliw dodanie 1 artukułu
                        action = DBArticleSave;
                    }
                }
                return true;
            }
        }

        private void DBArticleUpdate(byte[] fileInBytes, string fileName)
        {
            using (var context = new KonfContext())
            {
                context.Referaty.Attach(referat);

                if (referat.artykul2 == null)
                {                   
                    var art1 = referat.artykul1;
                    context.Artykuly.Attach(art1);
                    art1.NazwaPliku = fileName;
                    art1.Plik = fileInBytes;
                    art1.DataWyslania = DateTime.Now;
                    PlikArtukulu = fileName;
                    DataWyslaniaPlikuArtukulu = art1.DataWyslania.ToString();
                }
                else
                {
                    var art2 = referat.artykul2;
                    context.Artykuly.Attach(art2);
                    art2.NazwaPliku = fileName;
                    art2.Plik = fileInBytes;
                    art2.DataWyslania = DateTime.Now;
                    PlikPoprawki = fileName;
                    DataWyslaniaPlikuPoprawki = art2.DataWyslania.ToString();
                }
                context.SaveChanges();               
            }
        }

        private void DBArticleSave(byte[] fileInBytes, string fileName)
        {
            using (var context = new KonfContext())
            {
                context.Referaty.Attach(referat);
                var art = new Artykul(context.Artykuly.Count(), fileInBytes, fileName, DateTime.Now);

                if (referat.artykul1 == null)
                {
                    referat.artykul1 = art;
                    PlikArtukulu = fileName;
                    DataWyslaniaPlikuArtukulu = art.DataWyslania.ToString();
                }
                else
                {
                    referat.artykul2 = art;
                    PlikPoprawki = fileName;
                    DataWyslaniaPlikuPoprawki = art.DataWyslania.ToString();
                }                
                context.SaveChanges();                             
            }
        }

        /// <summary>
        /// Metoda sprawdzająca czy dla referatu jest możliwośc wysłania artykułu.
        /// </summary>
        /// <param name="referat">referat dla którego chcemy wyłać artykuł</param>
        /// <returns>true - można wysłac artykuł, false - nie można wysłać artykułu</returns>
        public static bool IsPosibleToSend(Referat referat)
        {
            var konferencja = UserSession.ActualKonferencja;
            if (referat.CzyZaakceptowany == StatusReferatu.NieZaakceptowany ||
               referat.CzyZaakceptowany == StatusReferatu.Zaakceptowany ||
                konferencja.DeadlineOstatecznyArtykulu < DateTime.Now ||
                (referat.CzyZaakceptowany == StatusReferatu.Zloszony &&
                    konferencja.DeadlineZglaszaniaArtykulu < DateTime.Now))
            {
                return false;
            }
            else
                return true;
        }

    }
}
