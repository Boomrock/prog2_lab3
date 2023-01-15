using System.Collections.Generic;
using System.Text;
using prog2_lab3.Models.Abstract.Observer;

namespace prog2_lab3.Models.realisation.Observer
{
    class Observable<T> : IObservable<T>
    {
        private List<IObserver<T>> observers;
        public Observable()
        {
            observers = new List<IObserver<T>>();
        }
        public void AddObserver(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(T data)
        {
            foreach (IObserver<T> item in observers)
            {
                item.Update(data);
            }
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            observers.Remove(observer);
        }
    }
}
