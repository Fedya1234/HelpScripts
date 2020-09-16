using UnityEngine;
using UnityEngine.AI;

namespace StateMashine.Actions
{
    public class Move : IAction
    {
        private NavMeshAgent _agent;
        private Vector3 _point;

        public Move(NavMeshAgent agent, Vector3 point)
        {
            _agent = agent;
            _point = point;
        }

        public void Cancel()
        {
            _agent.SetDestination(_agent.transform.position);
        }

        public void Start()
        {
            _agent.SetDestination(_point);
        }

        public bool Update()
        {
            return _agent.remainingDistance <= _agent.stoppingDistance;
        }
    }

}
