using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RegdollPart : MonoBehaviour
{
    public UnityEvent EventHit;

    public void OnHit()
    {
        EventHit?.Invoke();
    }
}
