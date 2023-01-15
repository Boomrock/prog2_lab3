using prog2_lab3.Command;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.Abstract.Observer;
using prog2_lab3.Models.realisation;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace prog2_lab3.ViewModel
{
    internal class LoginViewModel: prog2_lab3.Models.realisation.Observer.Observable<User>
    {
        public string Login { get; set;}
        public string Password{ get; set;}
        public RelayCommand commandSignIn { get; set; }
        private List<User> users;
        private IDataBase<object> dataBase;

        internal LoginViewModel(IDataBase<object> dataBase) { 
            this.dataBase   = dataBase;
            this.users      = (List<User>)dataBase.Get("Users");
            this.commandSignIn = new RelayCommand(this.SignIn);
        }

        void SignIn()
        {
            var user = users.Find(s => s.Login      == Login 
                                    && s.Password   == Password);

            if (user != null)
            {
                NotifyObservers(user);
            }
            else
            {
                //сделать уведомление о не правильных данных
            }
        }
    }
}
