using UnityEngine;

namespace StateMashine.Actions
{
    public class Scale : IAction
    {
        private Vector3 _scale;
        private Transform _transform;

        public Scale(Transform transform, Vector3 scale)
        {
            _transform = transform;
            _scale = scale;
        }

        public void Cancel()
        {
            
        }

        public void Start()
        {
            _transform.localScale = _scale;
        }

        public bool Update()
        {
            return true;
        }
    }

}