
namespace DesignPatterns.Iterator
{
    public interface IIterator
    {
        bool HasNext();
        object Next();
        void Reset();
        bool Add(object value);
        bool Remove(object value);
    }
}
