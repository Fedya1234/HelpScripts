using UnityEngine;

namespace StateMashine.Conditions
{
    public class IsInRange : ICondition
    {
        private float _rage;
        private Transform _parent;
        private Transform _target;

        public IsInRange(Transform parent, Transform target, float range)
        {
            _parent = parent;
            _target = target;
            _rage = range;
        }
        public bool Execute()
        {
            return Vector3.Distance(_parent.position, _target.position) < _rage;
        }
    }
}

