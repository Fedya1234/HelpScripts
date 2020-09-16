using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class TransformEvent : UnityEvent<Transform> { }

public class TriggerEnterExitTransform : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] bool _isTrigger;
    
    public TransformEvent EventTriggerEnter;
    public TransformEvent EventTriggerExit;

    public bool IsTriggered()
    {
        return _isTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            _isTrigger = true;
            EventTriggerEnter?.Invoke(other.transform);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            _isTrigger = false;
            EventTriggerExit?.Invoke(other.transform);
        }

    }
}
