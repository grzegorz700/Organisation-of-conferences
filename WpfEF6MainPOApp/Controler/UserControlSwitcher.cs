using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfEF6MainPOApp.View;

namespace WpfEF6MainPOApp.Controler
{
    /// <summary>
    /// Klasa odpowiada za swojne przełączanie UserControl w jedynym oknie aplikacji
    /// </summary>
    public class UserControlSwitcher
    {
        /// <summary>
        /// Pozwala usatwic referencje do okna głównego aplikacji
        /// </summary>
        public static MainWindow Switcher { private get; set; }

        /// <summary>
        /// Pozwala przelaczyc widok do wybranego widoku.
        /// </summary>
        /// <param name="newPage">
        /// UserControl do którego chcemy przełączyć okno główne aplikacji
        /// </param>
        public static void Switch(UserControl newPage)
        {
            Switcher.Switch(newPage);
        }
    }
}
