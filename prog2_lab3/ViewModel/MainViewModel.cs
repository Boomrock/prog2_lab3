using prog2_lab3.Models;
using prog2_lab3.Models.realisation;
using prog2_lab3.View;
using prog2_lab3.ViewModel.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace prog2_lab3.ViewModel
{
    class MainViewModel: ViewModel
    {
        Page mainPage;
        public MainViewModel()
        {
            /*  MainPage = new AdministratorView();
              MainPage.DataContext = new AdministratorViewModel();*/
            
            MainPage = new AdministratorView();
            MainPage.DataContext = new AdministratorViewModel();
        }
        public Page MainPage
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
/*
        public void LoadPage(Page page)
        {
            mainPage.DataContext = page;
            //отображаем
            MainPage.Content = page;
        }*/

    }
}
