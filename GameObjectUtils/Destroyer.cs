using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Destroyer : MonoBehaviour
{
    [SerializeField] float time;
    public void Execute()
    {
        if (time < 0.1f)
        {
            DestroySelf();
        }
        else
        {
            DOVirtual.DelayedCall(time, DestroySelf);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
