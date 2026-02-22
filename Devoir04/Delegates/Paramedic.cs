using Devoir04.Core;
using Devoir04.Observer;

namespace Devoir04.Delegates
{
    public class Paramedic : DelegateContext, IObserver
    {
        public Paramedic() : base("Paramedic")
        {
            HandleEmergency = () =>
                Console.WriteLine("Paramedic handles the emergency.");
        }

        public void Update(DelegateContext subject)
        {
            if (subject.CurrentState == "TIRED")
            {
                Console.WriteLine($"Paramedic observes {subject.Name} is TIRED.");
            }
        }
    }
}