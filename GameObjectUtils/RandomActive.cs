using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomActive : MonoBehaviour
{
    [SerializeField] List<GameObject> _gameObjects;

    void Start()
    {
        _gameObjects.ForEach(n => n.SetActive(false));
        _gameObjects[Random.Range(0, _gameObjects.Count)].SetActive(true);
    }
}
