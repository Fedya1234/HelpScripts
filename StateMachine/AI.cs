using StateMashine;
using StateMashine.States;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    AiManager _aiManager;
    void Start()
    {
        List<IState> states = new List<IState>();
        
        states.Add(new PatrolByGameObjects(GetComponent<NavMeshAgent>(),GameObject.FindGameObjectsWithTag("WayPoint")));
        states.Add(new Stay(1f));

        _aiManager = new AiManager(states);
    }

    void Update()
    {
        _aiManager.Update();
    }
}
