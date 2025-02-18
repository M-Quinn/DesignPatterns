
namespace DesignPatterns.Observer
{
    public interface ISubject
    {
        public void RegisterObserver(IObserver observer);
        public void UnregisterObserver(IObserver observer);
        public void NotifyObservers();
    }
}
