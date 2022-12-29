using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract.Observer
{
    interface IObservable<T>
    {
        public void AddObserver(IObserver<T> observer);
        public void RemoveObserver(IObserver <T> observer);
        public  void NotifyObservers(T data);
    }
}
