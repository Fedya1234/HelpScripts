using System;
using UnityEngine;
using UnityEngine.AI;
namespace StateMachineEngine
{ 
    public class MoveTo : IState
    {
        NavMeshAgent _agent;
        Transform _target;
        GetTarget _getTargetAction;

        public delegate Transform GetTarget();

        public MoveTo(NavMeshAgent agent, GetTarget getTargetAction)
        {
            _agent = agent;
            _getTargetAction = getTargetAction;
        }

        public void OnEnter()
        {
            _target = _getTargetAction();
            _agent.enabled = true;
            _agent.SetDestination(_target.position);
            
        }

        public void OnExit()
        {
            _agent.enabled = false;
        }

        public void Tick()
        {
            _agent.SetDestination(_target.position);
        }

    }
}