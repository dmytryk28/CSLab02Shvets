using Lab02Shvets.ViewModel;
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

namespace Lab02Shvets.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private readonly PersonViewModel _viewModel;
        
        public PersonView()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonViewModel();
        }

        private void DateChoice_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateChoice.SelectedDate.HasValue)
                _viewModel.BirthDate = DateChoice.SelectedDate.Value;
        }
    }
}
