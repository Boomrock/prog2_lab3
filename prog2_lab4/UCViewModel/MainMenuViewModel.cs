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
    internal class MainMenuViewModel : IObservable<Model.Page>, IObserver<Model.Page>
    {
        public RelayCommand OpenTranslationCheckCommand { get; set; }
        public RelayCommand OpenTranslationWordsCommand { get; set; }
        public RelayCommand OpenAddNewWordsCommand { get; set; }
        Model.Page AddNewWords, TranslationCheck, TranslationWords;
        Model.Page page;
        public MainMenuViewModel( UserControl View , IObserver<Model.Page> MainWindowViewModel)
        {
            OpenTranslationCheckCommand = new RelayCommand(OpenTranslationCheck);
            OpenTranslationWordsCommand = new RelayCommand(OpenTranslationWords);
            OpenAddNewWordsCommand = new RelayCommand(OpenAddNewWords);
            page = new Model.Page(View, this);
            AddNewWords = new Model.Page(new AddNewWordsView(), new AddNewWordsViewModel(page));
            TranslationCheck = new Model.Page(new TranslationCheckView(), new TranslationCheckViewModel(page));
            TranslationWords = new Model.Page(new TranslationWordsView(), new TranslationWordsViewModel(page));
            ((IObservable<Model.Page>)AddNewWords.DataContext).AddObserver(MainWindowViewModel);
            ((IObservable<Model.Page>)TranslationCheck.DataContext).AddObserver(MainWindowViewModel);
            ((IObservable<Model.Page>)TranslationWords.DataContext).AddObserver(MainWindowViewModel);
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
            _pages[0].Update(data);
        }

        public void Update(Model.Page data)
        {
            NotifyObservers(data);
        }
    }
}
