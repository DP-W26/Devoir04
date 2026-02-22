using Devoir04.Core;
using Devoir04.Observer;

namespace Devoir04.Delegates
{
    public class Nurse : DelegateContext, IObserver
    {
        public Nurse() : base("Nurse")
        {
            HandleEmergency = () =>
                Console.WriteLine("Nurse assists during emergency.");
        }

        public void Update(DelegateContext subject)
        {
            if (subject.CurrentState == "TIRED")
            {
                Console.WriteLine($"Nurse observes {subject.Name} is TIRED.");
            }
        }
    }
}