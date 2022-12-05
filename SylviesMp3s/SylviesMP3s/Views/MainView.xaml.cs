using System.Windows;
using SylviesMp3s.ViewModels;

namespace SylviesMp3s
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            vm = new MainViewModel();

            DataContext = vm;
        }
    }
}
