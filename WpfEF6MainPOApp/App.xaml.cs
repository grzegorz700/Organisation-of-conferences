using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfEF6MainPOApp.Controler;
using WpfEF6MainPOApp.Migrations;
using WpfEF6MainPOApp.Model.RawModel;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.View;

namespace WpfEF6MainPOApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void App_Startup(object sender, StartupEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("@MY@@@@    App_Startup @My@");
            
            MainWindow mainWindow = new MainWindow();
            UserControlSwitcher.Switcher = mainWindow;
 
            var control = new MainMenuController();
            control.SwitchToView();
            mainWindow.Show();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("@MY@@@@    OnStartup @My@");
            Database.SetInitializer(new DbInitializer());
            using (var context = new KonfContext())
            {
                if (context.Prelegenci.Count() == 0)
                {
                    System.Diagnostics.Debug.WriteLine("@MY@@@@    Cos poszlo nie tak z inicjalizacją DB @My@");
                }
                else
                {
                    //Imitacja Zalogowanego użytkownika
                    UserSession.ActualPrelegent = context.Prelegenci.First();
                    UserSession.ActualKonferencja = context.Konferencje.First();
                }
            }
            base.OnStartup(e);
            
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<KonfContext,                      Configuration>());        
        }

    }
}
