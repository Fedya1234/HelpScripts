using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class TrigerEvent : MonoBehaviour
{
    [SerializeField] string[] _tags;
    public UnityEvent EventTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            EventTrigger?.Invoke();
        }
    }
}
