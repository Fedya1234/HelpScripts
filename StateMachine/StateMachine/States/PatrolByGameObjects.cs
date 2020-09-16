using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;
using StateMashine.Actions;

namespace StateMashine.States
{
    public class PatrolByGameObjects : IState
    {
        NavMeshAgent _agent;
        GameObject[] _points;
        float _waitTime = 0.5f;

        public PatrolByGameObjects(NavMeshAgent agent, GameObject[] points)
        {
            _agent = agent;
            _points = points;
        }

        public State Execute()
        {
            Debug.Log(this.ToString() + "_Executed");

            List<IAction> actions = new List<IAction>();
            foreach (GameObject point in _points)
            {
                actions.Add(new Move(_agent, point.transform.position));
                actions.Add(new Wait(_waitTime));
            }
            List<ICondition> conditions = new List<ICondition>() {};//new IsTimePass(4f)
            return new State(conditions, actions);
        }

        public bool IsSelect()
        {
            return _points.Length > 0;
        }
    }
}
