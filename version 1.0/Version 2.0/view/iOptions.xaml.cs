using System.Windows.Controls;
using Version_2._0.ViewModel;

namespace Version_2._0.view
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class iOptions : UserControl
    {
        iOptionViewModel _instance = iOptionViewModel.getInstance();
        public iOptions()
        {
            DataContext = iOptionViewModel.getInstance();
            InitializeComponent();
        }
    }
}
