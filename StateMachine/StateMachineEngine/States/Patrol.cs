using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

namespace StateMachineEngine
{
    public class Patrol : IState
    {
        NavMeshAgent _agent;
        List<Transform> _points;
        int _currentPoint;

        public Patrol(NavMeshAgent agent, List<Transform> points)
        {
            _agent = agent;
            _points = points;
            _currentPoint = 0;
        }

        public void OnEnter()
        {
            Vector3 pointToMove = _points.OrderBy(n => Vector3.Distance(_agent.transform.position, n.position)).First().position;
            _agent.enabled = true;
            _agent.SetDestination(pointToMove);
            
        }

        public void OnExit()
        {
            _agent.SetDestination(_agent.transform.position);
            _agent.enabled = false;
        }

        public void Tick()
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _currentPoint++;
                if (_currentPoint >= _points.Count)
                {
                    _currentPoint = 0;
                }
                _agent.SetDestination(_points[_currentPoint].position);
            }
        }

    }
}
