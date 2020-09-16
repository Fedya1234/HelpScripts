using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;
public class TimedTrigger : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] float _time;
    public UnityEvent EventTrigger;
    public UnityEvent EventTimePass;
    private void OnTriggerEnter(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            EventTrigger?.Invoke();
            DOVirtual.DelayedCall(_time, EventPausePast);
        }
    }

    private void EventPausePast()
    {
        EventTimePass?.Invoke();
    }
}
