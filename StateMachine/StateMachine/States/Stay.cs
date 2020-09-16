using StateMashine.Actions;
using System.Collections.Generic;
using UnityEngine;

namespace StateMashine.States
{
    public class Stay : IState
    {
        private float _time;
        public Stay(float time)
        {
            _time = time;
        }

        public State Execute()
        {
            Debug.Log(this.ToString() + "_Executed");

            List<IAction> actions = new List<IAction>() { new Wait(_time) };
            List<ICondition> conditions = new List<ICondition>() { };
            return new State(conditions, actions);
        }

        public bool IsSelect()
        {
            return true;
        }

    }
}

