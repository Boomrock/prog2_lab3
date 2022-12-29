namespace prog2_lab3.Models.Abstract.Observer
{
    public interface IObserver<T>
    {
        void Update(T data);
    }
}