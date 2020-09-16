using UnityEngine;
using System.Linq;
namespace StateMachineEngine
{
    public class FindTarget : IState
    {
        IObject _player;
        public FindTarget(IObject player)
        {
            _player = player;
        }

        public void OnEnter()
        {
           // _player.MovePoint = Object.FindObjectsOfType<WayPoint>().Select(n => n.transform.position).OrderBy(t => Random.Range(0, int.MaxValue)).FirstOrDefault();
        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }

    }
}
