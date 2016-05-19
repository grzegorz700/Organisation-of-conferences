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
    /// Interaction logic for SelectionReferat.xaml
    /// </summary>
    public partial class SelectionReferat : UserControl
    {
        /// <summary>
        /// Akcja wywoływana po nacisnieciu lewego dolnego przycisku
        /// </summary>
        public Action ButtonCancelAction { get; set; }
        /// <summary>
        /// Akcja wywoływana po nacisnieciu prawego dolnego przycisku
        /// </summary>
        public Action ButtonSelectAction { get; set; }
        /// <summary>
        /// Akcja wywoływana po zmianie wyboru tematu z listy rozwijanej.
        /// </summary>
        public Action<int> ComboBoxSelectionChangeAction { get; set; } 
        
        /// <summary>
        /// Konstruktor widoku dla Wyboru referatu
        /// </summary>
        public SelectionReferat()
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

        private void btnSelect(object sender, RoutedEventArgs e)
        {
            if (ButtonSelectAction != null)
            {
                ButtonSelectAction();
            }
        }

        private void cb_selection_change(object sender, SelectionChangedEventArgs e)
        {
            if (ButtonSelectAction != null)
            {
                ComboBoxSelectionChangeAction((sender as ComboBox).SelectedIndex);
            }    
        }
    }
}
