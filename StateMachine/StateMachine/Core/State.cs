using System.Collections.Generic;

namespace StateMashine
{
    public class State
    {
        private List<ICondition> _conditions;
        private List<IAction> _actions;

        public State(List<ICondition> conditions, List<IAction> actions)
        {
            _actions = actions;
            _conditions = conditions;
        }

        public void Start()
        {
            _actions[0].Start();
        }

        public bool Update()
        {
            if (_actions.Count == 0) return true;
            if (_actions[0].Update())
            {
                _actions.RemoveAt(0);
                if (_actions.Count > 0) _actions[0].Start();
            }
            return IsCancel();
        }

        public void Cancel()
        {
            if (_actions.Count > 0) _actions[0].Cancel();
        }

        private bool IsCancel()
        {
            foreach (ICondition condition in _conditions)
            {
                if (condition.Execute())
                {
                    return true;
                }
            }
            return false;
        }
    }

}

