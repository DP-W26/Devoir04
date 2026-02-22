using Devoir04.Core;

namespace Devoir04.Observer
{
    public interface IObserver
    {
        void Update(DelegateContext subject);
    }
}