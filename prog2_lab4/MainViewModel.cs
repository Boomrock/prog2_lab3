
using prog2_lab3.Models.Abstract.Observer;
using prog2_lab4.UCView;
using prog2_lab4.UCViewModel;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace prog2_lab4
{
     class MainViewModel : ViewModelTemplate, prog2_lab3.Models.Abstract.Observer.IObserver<Model.Page>
    {
        private UserControl mainPage;
        /*private readonly ILocalDataBase<object> dataBase;
*/
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

        int check;
        public MainViewModel()
        {
            //путь до базы данных 
            //string path = $".\\DataBaseJson.txt";
            //Соединение с базой данных
            // dataBase = new JsonDataBase(path);
            check = 10;
            var view = new MainMenu(); 
            Model.Page MainMenu1 = new Model.Page(view, new MainMenuViewModel(view, this));
            ((MainMenuViewModel)MainMenu1.DataContext).AddObserver(this);
            check = 0;
             
            OpenPage(MainMenu1);



        }
        // определение асинхронного метода


        public void Update(Model.Page data)
        {

            OpenPage(data);

            check += 1;

        }

        public void OpenPage(UserControl page, object dataContext)
        {
            MainPage = page;
            MainPage.DataContext = dataContext;
        }
        public void OpenPage(Model.Page page)
        {
            MainPage = page.UserControl;
            MainPage.DataContext = page.DataContext;
        }

    }
}
