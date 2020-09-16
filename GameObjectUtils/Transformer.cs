using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Transformer : MonoBehaviour
{
    [SerializeField] float _time;
    [SerializeField] Vector3 _point;
    [SerializeField] Ease _ease = Ease.Unset;
    [SerializeField] UnityEvent OnEnding;
    public void Execute()
    {
        transform.DOLocalMove(_point, _time).SetEase(_ease).OnComplete(() => { OnEnding?.Invoke(); });
    }
}
