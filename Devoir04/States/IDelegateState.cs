using Devoir04.Core;

namespace Devoir04.States
{
    public interface IDelegateState
    {
        string Name { get; }
        void Handle(DelegateContext context);
    }
}