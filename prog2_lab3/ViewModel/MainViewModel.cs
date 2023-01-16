using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using prog2_lab3.Models.realisation.DataBase;
using prog2_lab3.Models.realisation.Observer;
using prog2_lab3.View;
using prog2_lab3.ViewModel.Administrator;
using System.Collections.Generic;
using System.Windows.Controls;

namespace prog2_lab3.ViewModel
{
    class MainViewModel: ViewModel, prog2_lab3.Models.Abstract.Observer.IObserver<User>
    {
        private UserControl mainPage;
        private readonly IDataBase<object> dataBase;
        public MainViewModel()
        {
            //путь до базы данных 
            string path = $".\\DataBaseJson.txt";
            //Соединение с базой данных
            dataBase = new DataBaseJsone(path);

            //dataBase.Set("Users", new List<User> { new User(1, "pass", "pass", "Fedor", "Lyagushin", "Alekseevich", Rights.User)});

            var LoginDataContext = new LoginViewModel(dataBase);
            LoginDataContext.AddObserver(this);
            OpenPage(new LoginView(), LoginDataContext);

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
        void OpenPage(UserControl page, object DataContext) 
        {
            MainPage = page;
            MainPage.DataContext = DataContext;
        }
        public void Update(User data)
        {
            if (data.Right == Rights.User)
            {
                OpenPage(new UserView(), new UserViewModel(data, dataBase));
            }
            else if (data.Right == Rights.Administator)
            {
                OpenPage(new AdministratorView(), new AdministratorViewModel(dataBase));
            }
        }
    }
}
