using System.Windows;
using Microsoft.Azure.Management.Network.Models;
using SylviesMp3s.ViewModels;

namespace SylviesMp3s
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel vm;

        public MainViewModel VM
        {
            get { return vm; }
            set { vm = value;}
        }


        public MainWindow()
        {
            InitializeComponent();

            vm = new MainViewModel();

            DataContext = vm;
        }
    }
}
