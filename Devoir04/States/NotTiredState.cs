using Devoir04.Core;

namespace Devoir04.States
{
    public class NotTiredState : IDelegateState
    {
        public string Name => "NOTTIRED"; // syntax => is used for expression-bodied members, a concise syntax for read-only properties

        public void Handle(DelegateContext context)
        {
            // Normal behavior
        }
    }
}