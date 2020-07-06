using System;

namespace Sand.StateMachine
{
    public class State
    {
        protected Machine Machine { get; set; }
        protected Action<Machine> ExitAction { get; set; }

        public State(Action<Machine> exitAction)
        {
            ExitAction = exitAction;
        }

        public virtual void Start(Machine machine, object reference)
        {
            Machine = machine;
        }

        public virtual void Begin()
        {

        }

        public virtual void End()
        {

        }

        public virtual void Run()
        {
            TryExit();
        }

        public virtual void TryExit()
        {
            ExitAction?.Invoke(Machine);
        }
    }
}
