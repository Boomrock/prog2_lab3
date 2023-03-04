using prog2_lab3.Models.Abstract.Observer;
using prog2_lab4.Command;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_lab4.UCViewModel
{
    internal class TranslationCheckViewModel : IObservable<Model.Page>
    {
        public RelayCommand BackToMainMenuCommand { get; set; }
        private Model.Page MainMenu;
        public TranslationCheckViewModel(Model.Page MainMenu)
        {
            BackToMainMenuCommand = new RelayCommand(BackToMainMenu);
            this.MainMenu = MainMenu;
        }

        private void BackToMainMenu()
        {
            NotifyObservers(MainMenu);
        }

        #region observer
        List<IObserver<Model.Page>> _pages;
        public void AddObserver(IObserver<Model.Page> observer)
        {
            if (_pages == null)
            {
                _pages = new List<IObserver<Model.Page>>();
            }
            _pages.Add(observer);
        }

        public void RemoveObserver(IObserver<Model.Page> observer)
        {
            _pages.Remove(observer);
        }

        public void NotifyObservers(Model.Page data)
        {
            _pages[0].Update(data);
        }
        #endregion
    }
}