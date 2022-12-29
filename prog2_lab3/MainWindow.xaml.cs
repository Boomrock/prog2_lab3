using prog2_lab3.View;
using prog2_lab3.ViewModel;
using prog2_lab3.ViewModel.Administrator;
using System.Windows;
using System.Windows.Controls;

namespace prog2_lab3
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }



    }
}
