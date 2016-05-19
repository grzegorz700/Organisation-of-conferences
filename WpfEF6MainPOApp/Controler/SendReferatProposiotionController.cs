using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.View;

namespace WpfEF6MainPOApp.Controler
{
    /// <summary>
    /// Klasa SendReferatProposiotionController odpowiada za obsługę  widoku wysyłania propozycji referatu na konferecję.
    /// Obiekt odbiera informacje z interfejsu i przekazuje ją do viewmodelu.
    /// </summary>
    public class SendReferatProposiotionController
    {
        private SendfReferatProposiotion view;
        private SendReferatProposiotionViewModel vm;
        private UserControl backPage;

        /// <summary>
        /// Konstruktor Klasy SendReferatProposiotionController odpowiada stowrzenie viewmodelu oraz podlaczenie go do DataContextu widoku.
        /// Ponadto odpowiada za podłączenie elemetów intefejsu do ich abługi(przez mechanizm Akcji).
        /// </summary>
        /// <param name="backPage">
        ///     Parametr wzakujacy na okno(UserControl) powrotu
        /// </param>
        public SendReferatProposiotionController(UserControl backPage)
        {
            this.backPage = backPage;
            vm = new SendReferatProposiotionViewModel();
            view = new SendfReferatProposiotion() { DataContext = vm };

            view.ButtonCancelAction = () => UserControlSwitcher.Switch(backPage);
            view.ButtonSendAction = sendProposition;
        }

        private void sendProposition(){
            string error;
            bool resultVM = vm.sendProposition(out error);
            if (resultVM)
            {
                var resultUI = MessageBox.Show("Wyslano");
                //if (resultUI == MessageBoxResult.OK)
                //{
                    UserControlSwitcher.Switch(backPage);
                //}
            }
            else
            {
                MessageBox.Show(error,"Błędne dane", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Pozwala przelaczyc widok do widoku ubsługiwanego przez ten kontroler.
        /// </summary>
        public void SwitchToView()
        {
            UserControlSwitcher.Switch(view);
        }

        /// <summary>
        /// Sprawdza czy jest możliwe przełączenie sie na ten widok.
        /// </summary>
        /// <returns>
        /// true - przełączenie sie na ten widok jest możliwe, false w przeciwnym przypadku
        /// </returns>
        public static bool IsPosibleToChangeviewToThis()
        {
            return UserSession.ActualKonferencja.DeadlineZglaszaniaArtykulu > DateTime.Now;
        }
    }
}