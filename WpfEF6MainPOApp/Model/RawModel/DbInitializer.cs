using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEF6MainPOApp.Model.RawModel
{
    class DbInitializer : DropCreateDatabaseAlways<KonfContext>
    {
        protected override void Seed(KonfContext context)
        {
            base.Seed(context);
   
            System.Diagnostics.Debug.WriteLine("@MY@@@@    DbInitializerMy- Dodaje dane @My@");

            var mainPrelegent = new Prelegent() {ID = 1, Imie = "Grzegorz", Nazwisko = "Brzęczyszczykiewicz", Email = "gregbrzeczy@gmail.com", Haslo = "a221ezxwd31", OsrodekBadawczy = "Politechnika Wrocławska", TytulNaukowy = "mg. inż." };
            var secondPrelegent = new Prelegent() { ID = 2, Imie = "Gustaw", Nazwisko = "Nowacki", Email = "gucio333@gmail.com", Haslo = "a221sasasa", OsrodekBadawczy = "Politechnika Wrocławska", TytulNaukowy = "mg. inż." };
            context.Prelegenci.Add(mainPrelegent);
            context.Prelegenci.Add(secondPrelegent);
            context.SaveChanges();

            var sala = new Sala { ID = 1, MaxMiejsc = 270, Nazwa = "329 A-1" };
            var sala2 = new Sala { ID = 2, MaxMiejsc = 120, Nazwa = "201 B-4" };
            context.Sale.Add(sala);
            context.Sale.Add(sala2);
            context.SaveChanges();

            var konferencja = new Konferencja { ID = 1, CenaNetto = 0,
                DeadlineZglaszaniaArtykulu =    new DateTime(2016, 2, 14, 15, 30, 0),
                DeadlineInformacjiOAkcetpacji = new DateTime(2016, 2, 18, 16, 30, 0),
                DeadlineOstatecznyArtykulu =    new DateTime(2016, 2, 22, 17, 30, 0)
                };
            context.Konferencje.Add(konferencja);
            context.SaveChanges();

            var referat = new Referat {ID = 1,   Abstrakt = "Android to platforma ...", Tytul = "Android", CzyZaakceptowany = StatusReferatu.Zloszony, DataRozpoczecia = DateTime.Today, DataZakonczenia = DateTime.Now, CenaNetto = 25.24, sala = sala, konferencja = konferencja};
            referat.prelegent.Add(mainPrelegent);

            var referat2 = new Referat {ID = 2,  Abstrakt = "Bezpieczenstwo informacji to ...", Tytul = "Bezpieczeństwo", CzyZaakceptowany = StatusReferatu.Zloszony, DataRozpoczecia = DateTime.Today, DataZakonczenia = DateTime.Now, CenaNetto = 15.24, sala = sala2, konferencja = konferencja };
            referat2.prelegent.Add(mainPrelegent);
            referat2.prelegent.Add(secondPrelegent);

            var referat3 = new Referat { ID = 3, Abstrakt = "Windows 10 to platforma ...", Tytul = "Windows 10", CzyZaakceptowany = StatusReferatu.Zloszony, DataRozpoczecia = DateTime.Today, DataZakonczenia = DateTime.Now, CenaNetto = 35.24, sala = sala2, konferencja = konferencja };
            referat3.prelegent.Add(mainPrelegent);

            context.Referaty.Add(referat);
            context.SaveChanges();

            context.Referaty.Add(referat2);
            context.SaveChanges();

            context.Referaty.Add(referat3);
            context.SaveChanges();

            if (DateTime.Now > konferencja.DeadlineZglaszaniaArtykulu)
            {
                var artykul1 = new Artykul(1, new byte[] { 1, 1, 0, 1, 0 }, "Nowy plik.txt", new DateTime(2016, 2, 8, 15, 30, 0));
                referat.CzyZaakceptowany = StatusReferatu.DoPoprawy;
                context.Artykuly.Add(artykul1);
                referat.artykul1 = artykul1;
                context.SaveChanges();
                referat2.CzyZaakceptowany = StatusReferatu.Zaakceptowany;
                referat3.CzyZaakceptowany = StatusReferatu.NieZaakceptowany;
                context.SaveChanges();
            }
        }
    }
}
