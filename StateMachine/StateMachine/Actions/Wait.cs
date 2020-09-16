using UnityEngine;

namespace StateMashine.Actions
{
    public class Wait : IAction
    {
        private float _time;
        private float _endTime;

        public Wait(float time)
        {
            _time = time;
        }

        public void Cancel()
        {

        }

        public void Start()
        {
            _endTime = Time.time + _time;
        }

        public bool Update()
        {
            return Time.time > _endTime;
        }
    }

}
