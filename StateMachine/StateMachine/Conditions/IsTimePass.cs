using UnityEngine;

namespace StateMashine.Conditions
{
    public class IsTimePass : ICondition
    {
        private float endTime;

        public IsTimePass(float time)
        {
            endTime = Time.time + time;
        }
        public bool Execute()
        {
            return Time.time > endTime;
        }
    }
}
