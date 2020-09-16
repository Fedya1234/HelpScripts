using System.Collections.Generic;
using UnityEngine;

namespace StateMashine
{
    public class AiManager
    {
        List<IState> _states;
        List<IState> _urgentStates;
        State _currentState;
        int _currentStateIndex;

        public AiManager(List<IState> states)
        {
            _states = states;
            _urgentStates = new List<IState>();
        }

        public void Update()
        {
            if (_currentState == null)
            {
                FindState();
            }
            if (_currentState.Update())
            {
                FindState();
            }
            else
            {
                FindBetterState(); //Can be called not so fast
            }
        }

        public void AddUrgentState(IState newState, bool isClearUrgentStates)
        {
            if (isClearUrgentStates)
            {
                CancelCurrentState();
                _urgentStates.Clear();
                SelectState(newState);
            }
            else
            {
                if (_urgentStates.Count > 0)
                {
                    _urgentStates.Add(newState);
                }
                else
                {
                    CancelCurrentState();
                    SelectState(newState);
                }
                
            }

            
        }

        public void AddNewState(IState newState, int priority = 0, bool isUpdateStates = true)
        {
            priority = Mathf.Min(priority, _states.Count);

            _states.Insert(priority, newState);

            if (isUpdateStates)
            {
                CancelCurrentState();
                FindState();
            }
        }

        private bool FindBetterState()
        {
            IState betterState = GetBetterState();
            if (betterState != null){
                CancelCurrentState();
                SelectState(betterState);
                return true;
            }
            else
            {
                return false;
            }

        }

        private IState GetBetterState()
        {
            if (_currentStateIndex == -1) return null;
            for (int i = 0; i < _currentStateIndex; i++)
            {
                if (_states[i].IsSelect())
                {
                    return _states[i];
                }
            }
            return null;
        }

        private IState FindNewState()
        {
            if (_urgentStates.Count > 0)
            {
                IState newUrgentState = _urgentStates[0];
                _urgentStates.RemoveAt(0);
                return newUrgentState;
            }

            for (int i = 0; i < _states.Count; i++)
            {
                if (_states[i].IsSelect())
                {
                    return _states[i];
                }
            }

            throw new System.Exception("NO STATE FOUND IN STATES LIST IN AI MANAGER");
        }

        private void CancelCurrentState()
        {
            if (_currentState != null)
            {
                _currentState.Cancel();
            }
        }

        private void FindState()
        {
            SelectState(FindNewState());
        }

        private void SelectState(IState newState)
        {
            _currentStateIndex = _states.IndexOf(newState);
            _currentState = newState.Execute();
            _currentState.Start();
        }
    }

}
