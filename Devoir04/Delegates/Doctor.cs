using Devoir04.Core;
using Devoir04.Observer;

namespace Devoir04.Delegates
{
    public class Doctor : DelegateContext, IObserver
    {
        private readonly DelegateContext _paramedic;
        private readonly DelegateContext _nurse;

        public Doctor(Paramedic paramedic, Nurse nurse) : base("Doctor")
        {
            _paramedic = paramedic;
            _nurse = nurse;

            HandleEmergency = () => Console.WriteLine("Doctor handles the emergency.");
        }

        public void Update(DelegateContext subject)
        {
            // Always reevaluate on any change (tired or not)
            Console.WriteLine($"Doctor observes {subject.Name} is {subject.CurrentState}.");
            ReevaluateDelegation();
        }

        protected override void OnStateChanged()
        {
            // Reevaluates when Doctor itself changes state
            ReevaluateDelegation();
        }

        private void ReevaluateDelegation()
        {
            if (CurrentState == "NOTTIRED")
            {
                HandleEmergency = () => Console.WriteLine("Doctor handles the emergency.");
                return;
            }

            if (_paramedic.CurrentState == "NOTTIRED")
            {
                HandleEmergency = _paramedic.PerformEmergency;
                Console.WriteLine("Doctor delegated to Paramedic.");
                return;
            }

            if (_nurse.CurrentState == "NOTTIRED")
            {
                HandleEmergency = _nurse.PerformEmergency;
                Console.WriteLine("Doctor delegated to Nurse.");
                return;
            }

            HandleEmergency = () => Console.WriteLine("Everyone is TIRED. No one handles emergency.");
        }
    }
}