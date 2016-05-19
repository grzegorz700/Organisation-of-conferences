using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfEF6MainPOApp.Model.RawModel;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.View;
using System.Windows;

namespace WpfEF6MainPOApp.Controler
{
    /// <summary>
    /// Klasa SendArtykulController odpowiada za obsługę  widoku wysyłania pliku do artykułu.
    /// Obiekt odbiera informacje z interfejsu i przekazuje ją do viewmodelu.
    /// </summary>
    public class SendArtykulController
    {
        private SendArtykul view;
        private SendArtykulViewModel viewModel;
        private UserControl backPage;

        /// <summary>
        /// Konstruktor Klasy SendArtykulController odpowiada stowrzenie viewmodelu oraz podlaczenie go do DataContextu widoku.
        /// Ponadto odpowiada za podłączenie elemetów intefejsu do ich abługi(przez mechanizm Akcji).
        /// </summary>
        /// <param name="referat">
        ///     To parametr informujacy o tymm do ktorego referatu chcemy wysylac artykuł
        /// </param>
        /// <param name="backPage">
        ///     Parametr wzakujacy na okno(UserControl) powrotu
        /// </param>
        public SendArtykulController(Referat referat,  UserControl backPage)
        {
            viewModel = new SendArtykulViewModel(referat);
            view = new SendArtykul() { DataContext = viewModel };

            this.backPage = backPage;
            view.ButtonCancelAction = () => UserControlSwitcher.Switch(backPage);
            view.ButtonSendArtykulAction = () => sendArt();    
        }

        /// <summary>
        /// Pozwala przelaczyc widok do widoku ubsługiwanego przez ten kontroler.
        /// </summary>
        public void SwitchToView()
        {
            UserControlSwitcher.Switch(view);
        }

        private void sendArt()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = SendArtykulViewModel.FileFilter;
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var resultSending = viewModel.sendingFile(openFileDialog);
                if (resultSending)
                {
                    view.ButtonSendArtykulAction = () => UserControlSwitcher.Switch(backPage);
                    view.RightButton.Content = "Ok";
                    view.LeftButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Błęd pliku. Sprawdz rozszerznie, czy plik nie jest pusty, albo czy nie jest większy niż 16MB", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        /// <summary>
        /// Sprawdza czy jest możliwe przełączenie sie na ten widok.
        /// </summary>
        /// <param name="referat">
        ///     okresla referat który chemy sprawdzic czy do niego mazna aktualnie wysłac referat
        /// </param>
        /// <returns>
        /// true - przełączenie sie na ten widok jest możliwe, false w przeciwnym przypadku
        /// </returns>
        public static bool IsPosibleToChangeviewToThis(Referat referat)
        {
            return SendArtykulViewModel.IsPosibleToSend(referat);
        }

    }
}
