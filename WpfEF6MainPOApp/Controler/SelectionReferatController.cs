using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfEF6MainPOApp.Model.RawModel;
using WpfEF6MainPOApp.Model.ViewModel;
using WpfEF6MainPOApp.View;

namespace WpfEF6MainPOApp.Controler
{
    /// <summary>
    /// Klasa SelectionReferatController odpowiada za obsługę  widoku wybory referatu do wysłania artykułu.
    /// Obiekt odbiera informacje z interfejsu i przekazuje ją do viewmodelu.
    /// </summary>
    public class SelectionReferatController
    {
        private SelectionReferat view;
        private SelectionReferatViewModel viewModel;
        private UserControl backPage;

        /// <summary>
        /// Konstruktor Klasy SelectionReferatController odpowiada stowrzenie viewmodelu oraz podlaczenie go do DataContextu widoku.
        /// Ponadto odpowiada za podłączenie elemetów intefejsu do ich abługi(przez mechanizm Akcji).
        /// </summary>
        /// <param name="backPage">
        ///     Parametr wzakujacy na okno(UserControl) powrotu
        /// </param>
        public SelectionReferatController( UserControl backPage)
        {
            this.backPage = backPage;

            viewModel = new SelectionReferatViewModel();
            view = new SelectionReferat { DataContext = viewModel };

            view.ButtonCancelAction = () => UserControlSwitcher.Switch(backPage);
            view.ComboBoxSelectionChangeAction = (index) => viewModel.setActualReferat(index);
            view.ButtonSelectAction = () => switchToSendArtukul();
        }

        private void  switchToSendArtukul(){
            if (SendArtykulController.IsPosibleToChangeviewToThis(viewModel.ActualReferat))
            {
                SendArtykulController controler = new SendArtykulController(viewModel.ActualReferat, backPage);
                controler.SwitchToView();
            }
            else
            {
                MessageBox.Show("Nie można już wysłać artykułów do tego referatu!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// Pozwala przelaczyc widok do widoku ubsługiwanego przez ten kontroler.
        /// </summary>
        public void SwitchToView(){
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
            return SelectionReferatViewModel.IsPosibleToChangeviewToThis();
        }
    }
}
