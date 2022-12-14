using SylviesMp3s.Models;
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
    /// Logique d'interaction pour AlbumView.xaml
    /// </summary>
    public partial class AlbumView : UserControl
    {
        Playlists b4changes;
        public AlbumView()
        {
            InitializeComponent();
           // DataContext = new AlbumViewModel();
        }
        public int CheckCheckbox()
        {
            bool? ispublic = C1.IsChecked;
            int pubint = -1;
            if (ispublic == true)
            {
                return pubint = 1;
            }
            else
            {
                return pubint = 0;
            }
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            //string? _artist, string? _genre, string _title, int? _year, bool _is_public, int _id_user, string? _album_cover

            /// IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- IMPORTANT -- 
            /// CHANGE IDUSER

            int year = 0;
            b4changes = new Playlists(null, null, A1.Text, year, CheckCheckbox(), -1, null);
            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            A4.IsEnabled = true;
            A5.IsEnabled = true;



            A6.IsEnabled = true;
            A7.IsEnabled = true;

            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;

            C1.IsEnabled = true;

            PLAYLISTS.IsEnabled = false;

        }

        private void A6_Click(object sender, RoutedEventArgs e)
        {
            A1.IsEnabled = false;
            A6.IsEnabled = false;
            A7.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            A4.IsEnabled = false;
            A5.IsEnabled = false;

            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;

            C1.IsEnabled = false;

            PLAYLISTS.IsEnabled = true;
        }

        private void A7_Click(object sender, RoutedEventArgs e)
        {
            A1.Text = b4changes.Title;
            if (b4changes.Is_Public == 1)
            {
                C1.IsChecked = true;
            }
            else
            {
                C1.IsChecked = false;
            }


            A1.IsEnabled = false;
            A6.IsEnabled = false;
            A7.IsEnabled = false;

            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;

            C1.IsEnabled = false;

            PLAYLISTS.IsEnabled = true;
        }
    }
}
