using System.Windows;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pdf.IsChecked == true)
            {
                _instance.Pdf = true;
            }
            else
            {
                _instance.Pdf = false;
            }
            //
            if (jpeg.IsChecked == true)
            {
                _instance.Jpeg = true;
            }
            else
            {
                _instance.Jpeg = false;
            }
            //
            if (docx.IsChecked == true)
            {
                _instance.Docx = true;
            }
            else
            {
                _instance.Docx = false;
            }
            //
            if (txt.IsChecked == true)
            {
                _instance.Txt = true;
            }
            else
            {
                _instance.Txt = false;
            }
        }
    }
}
