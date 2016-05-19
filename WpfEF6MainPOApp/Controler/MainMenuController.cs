using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEF6MainPOApp.View;
using WpfEF6MainPOApp.Model.RawModel;
using WpfEF6MainPOApp.Model.ViewModel;
using System.Windows;

namespace WpfEF6MainPOApp.Controler
{
    /// <summary>
    /// Klasa MainMenuController odpowiada za obsługę Menu głównego aplikacji. Odbiera informacje z interfejsu i przekazuje ją do viewmodelu.
    /// </summary>
    public class MainMenuController
    {
        private MainMenu view;
        
        /// <summary>
        /// Konstruktor Klasy MainMenuController odpowiada za podlaczenie DataContext do widoku oraz podłączenie elemetów intefejsu do ich abługi(przez mechanizm Akcji).
        /// </summary>
        public MainMenuController()
        {
            view = new MainMenu() { DataContext = new UserSession()};

            view.ButtonSendArtToReferat =  SwitchToSendArt;
            view.ButtonSendSubjectOfReferat = SwitchToSendReferatProposiotion;
        }
        
        private void SwitchToSendArt()
        {            
            if(SelectionReferatController.IsPosibleToChangeviewToThis())
            {
                SelectionReferatController selectReferatControler = new SelectionReferatController(view);
                selectReferatControler.SwitchToView();
            }
            else
            {
                MessageBox.Show("Nie wysłano żadnych referatów!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SwitchToSendReferatProposiotion()
        {
            if (SendReferatProposiotionController.IsPosibleToChangeviewToThis())
            {
                SendReferatProposiotionController controler = new SendReferatProposiotionController(view);
                controler.SwitchToView();
            }
            else
            {
                MessageBox.Show("Upłynął termin wysyłania referatów", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Pozwala przełączyć się na okno główne aplikacji
        /// </summary>
        public void SwitchToView()
        {
            UserControlSwitcher.Switch(view);
        }

    }
}
