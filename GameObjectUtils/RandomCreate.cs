using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> _gameObjects;
    [SerializeField] bool isOnStart = true;
    [SerializeField] bool isLocal = true;
    void Start()
    {
        if (isOnStart)
            Execute();
    }

    public void Execute()
    {
        if (isLocal)
        {
            Instantiate(_gameObjects[Random.Range(0, _gameObjects.Count)], transform.position, transform.rotation, transform);
        }
        else
        {
            Instantiate(_gameObjects[Random.Range(0, _gameObjects.Count)], transform.position, transform.rotation);
        }
        
    }


}
