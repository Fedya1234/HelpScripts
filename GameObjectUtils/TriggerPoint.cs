using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] bool _isTrigger;
    public UnityEvent EventTriggerEnter;
    public UnityEvent EventTriggerExit;

    List<Transform> _currentColiders = new List<Transform>();

    public bool IsTriggered()
    {
        return _isTrigger;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            if (_currentColiders.Contains(other.transform) == false)
            {
                
                _currentColiders.Add(other.transform);
            }

            if (_currentColiders.Count == 1)
            {
                _isTrigger = true;
                EventTriggerEnter?.Invoke();
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            if (_currentColiders.Contains(other.transform))
            {
                _currentColiders.Remove(other.transform);
            }
            if (_currentColiders.Count == 0)
            {
                _isTrigger = false;
                EventTriggerExit?.Invoke();
            }
            
        }

    }
}
