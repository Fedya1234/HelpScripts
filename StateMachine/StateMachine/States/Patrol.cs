using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;
using StateMashine.Actions;

namespace StateMashine.States
{
    public class Patrol : IState
    {
        NavMeshAgent _agent;
        Transform[] _points;
        float _waitTime = 0.5f;

        public Patrol(NavMeshAgent agent, Transform[] points)
        {
            _agent = agent;
            _points = points;
        }

        public State Execute()
        {
            List<IAction> actions = new List<IAction>();
            foreach (Transform point in _points)
            {
                actions.Add(new Move(_agent, point.position));
                actions.Add(new Wait(_waitTime));
            }
            List<ICondition> conditions = new List<ICondition>() { };
            return new State(conditions, actions);
        }

        public bool IsSelect()
        {
            return _points.Length > 0;
        }
    }
}
