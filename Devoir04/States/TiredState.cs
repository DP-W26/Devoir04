using Devoir04.Core;

namespace Devoir04.States
{
    public class TiredState : IDelegateState
    {
        public string Name => "TIRED"; // syntax => is used for expression-bodied members, a concise syntax for read-only properties

        public void Handle(DelegateContext context)
        {
            context.NotifyFatigue();
        }
    }
}