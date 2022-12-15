using SylviesMp3s.ViewModels;
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

namespace SylviesMp3s.Views
{
    /// <summary>
    /// Logique d'interaction pour PlayListView.xaml
    /// </summary>
    public partial class PlayListView : UserControl
    {
        public PlayListView()
        {
            InitializeComponent();
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;

            B4.IsEnabled = true;
            B5.IsEnabled = true;

            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            A4.IsEnabled = true;
            A5.IsEnabled = true;
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;

            B4.IsEnabled = false;
            B5.IsEnabled = false;

            A1.IsEnabled = false;
            A1.Text = string.Empty;
            A2.IsEnabled = false;
            A3.Text = string.Empty;
            A3.IsEnabled = false;
            A3.Text = string.Empty;
            A4.IsEnabled = false;
            A4.Text = string.Empty;
            A5.IsEnabled = false;
            A5.Text = string.Empty;
        }
    }
}
