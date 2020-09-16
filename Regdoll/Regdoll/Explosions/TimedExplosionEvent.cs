using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedExplosionEvent : MonoBehaviour
{
    [SerializeField] float _minTime = 0.1f;
    [SerializeField] float _maxTime = 0.5f;
    public UnityEvent OnTimePass;
    private Tween _tween;
    bool _isUsed = false;

    public void Execute()
    {
        if (_isUsed == false)
        {
            _tween = DOVirtual.DelayedCall(Random.Range(_minTime, _maxTime), OnEnding);
            _isUsed = true;
        }
        
    }

    private void OnEnding()
    {
        OnTimePass?.Invoke();
        Destroy(this);
    }
}
