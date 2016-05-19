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
using System.Windows.Shapes;

namespace WpfEF6MainPOApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor głównego okna aplikacji(putstego) i jedynego w czasie działania całego programu
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("@MY@@@@    MainWindow @My@");        
        }

        /// <summary>
        /// Przełącza zawartośc głównego okna aplikaji powiększy różnymi UserControlami
        /// </summary>
        /// <param name="newPage"></param>
        public void Switch(UserControl newPage)
        {
            if(newPage != null)
            {
                this.Content = newPage;
            }
        }

    }
}
