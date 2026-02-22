using Devoir04.Observer;
using Devoir04.States;

namespace Devoir04.Core
{
    public abstract class DelegateContext : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private IDelegateState _state;

        protected DelegateContext(string name)
        {
            Name = name;
            _state = new NotTiredState();
        }

        public string Name { get; }

        public string CurrentState => _state.Name;

        public Action HandleEmergency { get; set; }

        public void SetState(IDelegateState state)
        {
            _state = state;

            Console.WriteLine($"{Name} changed state to {CurrentState}");

            _state.Handle(this);

            OnStateChanged();

            Notify();
        }

        protected virtual void OnStateChanged()
        {
        }

        public void Attach(IObserver observer) => _observers.Add(observer);

        public void Detach(IObserver observer) => _observers.Remove(observer);

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void NotifyFatigue()
        {
            Console.WriteLine($"{Name} is TIRED and may delegate responsibility.");
        }

        public void PerformEmergency()
        {
            HandleEmergency?.Invoke();
            // ** important: Invoke -> Executes the specified delegate on the thread that owns the control's underlying window handle.
            // If the control's handle does not exist yet, the delegate is invoked on the thread that created the control. **
            // Note: In this console application context, we don't have a UI thread, so we can directly invoke the delegate without worrying about cross-thread operations.                            
        }
    }
}