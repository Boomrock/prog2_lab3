using prog2_lab3.View;
using prog2_lab3.ViewModel.Administrator;
using System.Windows;
using System.Windows.Controls;

namespace prog2_lab3
{

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        OrderApproval
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ILoadWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            AdministratorViewModel vm = new AdministratorViewModel(this);
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;
            //загрузка стартовой View
            LoadPage(new AdministratorView());
        }

        public void LoadPage(Page page)
        {
            AdministratorViewModel vm = new AdministratorViewModel(this);
            //связываем их м/собой
            page.DataContext = vm;
            //отображаем
            MainFrame.Content = page;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
