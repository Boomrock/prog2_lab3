using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract.Observer
{
    interface IObservable<T>
    {
        void AddObserver(IObserver<T> observer);
        void RemoveObserver(IObserver <T> observer);
        void NotifyObservers(T data);
    }
}
