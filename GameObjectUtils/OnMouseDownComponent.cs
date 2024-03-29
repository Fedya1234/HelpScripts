﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnMouseDownComponent : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke();
    }

}
