using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { }

public class RotateCommand : MonoBehaviour
{
    [SerializeField] bool _isLocal = true;
    [SerializeField] Vector3 _localRotation;
    [SerializeField] float _time = 0.5f;
    [SerializeField] GameObjectEvent EventEnded;
    

    public void Execute(GameObject go)
    {
        if (go == null) go = this.gameObject;
        if (_isLocal)
        {
            go.transform.DOLocalRotate(_localRotation, _time).OnComplete(() => {
                EventEnded?.Invoke(go);
            });
        }
        else
        {
            go.transform.DORotate(_localRotation, _time).OnComplete(() => {
                EventEnded?.Invoke(go);
            });
        }
        
    }
}
