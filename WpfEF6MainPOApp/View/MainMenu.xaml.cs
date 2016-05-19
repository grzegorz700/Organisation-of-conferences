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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        /// <summary>
        /// Akcja wywoływana po nacisnieciu przycisku "Wyślij artykuł do referatu"
        /// </summary>
        public Action ButtonSendArtToReferat { get; set; }
        /// <summary>
        /// Akcja wywoływana po nacisnieciu przycisku "Wyślij propozycję referatu"
        /// </summary>
        public Action ButtonSendSubjectOfReferat { get; set; }

        /// <summary>
        /// Konstruktor widoku dla Menu głównego
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnSendArtToReferat(object sender, RoutedEventArgs e)
        {
            if (ButtonSendArtToReferat != null)
            {
                ButtonSendArtToReferat();
            }           
        }

        private void btnSendSubjectOfReferat(object sender, RoutedEventArgs e)
        {
            if (ButtonSendSubjectOfReferat != null)
            {
                ButtonSendSubjectOfReferat();
            } 
        }
    }
}
