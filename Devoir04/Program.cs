using Devoir04.Delegates;
using Devoir04.States;

namespace Devoir04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paramedic = new Paramedic();
            var nurse = new Nurse();
            var doctor = new Doctor(paramedic, nurse);

            doctor.Attach(paramedic);
            doctor.Attach(nurse);

            paramedic.Attach(doctor);
            nurse.Attach(doctor);

            var random = new Random();

            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(2000);

                paramedic.SetState(random.Next(0, 2) == 0 ? new TiredState() : new NotTiredState());
                nurse.SetState(random.Next(0, 2) == 0 ? new TiredState() : new NotTiredState());
                doctor.SetState(random.Next(0, 2) == 0 ? new TiredState() : new NotTiredState());

                doctor.PerformEmergency();
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}