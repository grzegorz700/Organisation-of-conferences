using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEF6MainPOApp.View
{
    /// <summary>
    /// Interaction logic for SendArtykul.xaml
    /// </summary>
    public partial class SendArtykul : UserControl
    {
        /// <summary>
        /// Akcja wywoływana po nacisnieciu lewego dolnego przycisku
        /// </summary>
        public Action ButtonCancelAction { get; set; }
        /// <summary>
        /// Akcja wywoływana po nacisnieciu prawego dolnego przycisku
        /// </summary>
        public Action ButtonSendArtykulAction { get; set; }

        /// <summary>
        /// Konstruktor widoku dla Wysyłania Artykułu
        /// </summary>
        public SendArtykul()
        {
            InitializeComponent();
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            if (ButtonCancelAction != null)
            {
                ButtonCancelAction();
                
            }
        }

        private void btnSendArt(object sender, RoutedEventArgs e)
        {
            if (ButtonCancelAction != null)
            {
                ButtonSendArtykulAction();
            }
        }


    }
}
