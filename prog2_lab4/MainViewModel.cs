
using prog2_lab3.Models.Abstract.Observer;
using prog2_lab4.UCView;
using prog2_lab4.UCViewModel;
using System.Windows.Controls;

namespace prog2_lab4
{
     class MainViewModel : ViewModelTemplate, IObserver<Model.Page>
    {
        protected UserControl mainPage;
        /*private readonly ILocalDataBase<object> dataBase;
*/
        int check;
        public MainViewModel()
        {
            //путь до базы данных 
            //string path = $".\\DataBaseJson.txt";
            //Соединение с базой данных
            // dataBase = new JsonDataBase(path);
            check = 10;
            Model.Page MainMenu = new Model.Page(new MainMenu(), new MainMenuViewModel());
            ((MainMenuViewModel)MainMenu.DataContext).AddObserver(this);
            check = 0;
            OpenPage(MainMenu);


        }
        public UserControl MainPage
        {
            get
            {
                return mainPage;
            }
            set
            {
                mainPage = value;
                OnPropertyChanged("MainPage");
            }
        }

        public void Update(Model.Page data)
        {
            MainPage = data.UserControl;

            OnPropertyChanged("MainPage");

        }

        protected void OpenPage(UserControl page, object dataContext)
        {
            MainPage = page;
            MainPage.DataContext = dataContext;
        }
        protected void OpenPage(Model.Page page)
        {
            MainPage = page.UserControl;
            MainPage.DataContext = page.DataContext;
        }

    }
}
