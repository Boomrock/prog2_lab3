using prog2_lab3.Models.Abstract.Observer;
using prog2_lab4.Command;
using prog2_lab4.UCView;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prog2_lab4.UCViewModel
{
    internal class MainMenuViewModel : IObservable<Model.Page>
    {
        public RelayCommand OpenTranslationCheckCommand { get; set; }
        public RelayCommand OpenTranslationWordsCommand { get; set; }
        public RelayCommand OpenAddNewWordsCommand { get; set; }
        Model.Page AddNewWords, TranslationCheck, TranslationWords;
        public MainMenuViewModel()
        {
            OpenTranslationCheckCommand = new RelayCommand(OpenTranslationCheck);
            OpenTranslationWordsCommand = new RelayCommand(OpenTranslationWords);
            OpenAddNewWordsCommand = new RelayCommand(OpenAddNewWords);
            AddNewWords = new Model.Page(new AddNewWordsView(), new AddNewWordsViewModel());
            TranslationCheck = new Model.Page(new TranslationCheckView(), new TranslationCheckViewModel());
            TranslationWords = new Model.Page(new TranslationWordsView(), new TranslationWordsViewModel());
        }

        private void OpenAddNewWords()
        {
            NotifyObservers(AddNewWords);
        }

        private void OpenTranslationWords()
        {
            NotifyObservers(TranslationWords);

        }

        private void OpenTranslationCheck()
        {
            NotifyObservers(TranslationCheck);

        }

        List<IObserver<Model.Page>> _pages;
        public void AddObserver(IObserver<Model.Page> observer)
        {
            if(_pages == null)
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
            _pages.ForEach(i=>i.Update(data));
        }
    }
}
