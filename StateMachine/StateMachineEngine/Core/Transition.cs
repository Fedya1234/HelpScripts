using System;

namespace StateMachineEngine
{
    public class Transition
    {
        public IState To { get; private set; }
        public Func<bool> Condition { get; }

        public Transition(IState to, Func<bool> predicate)
        {
            To = to;
            Condition = predicate;
        }
    }
}