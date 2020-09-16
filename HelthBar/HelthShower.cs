using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HelthShower : MonoBehaviour
{
    Slider _slider;
    CanvasGroup _canvasGroup;
    Sequence _mySequence;
    void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetValue(float value)
    {
        value = Mathf.Clamp01(value);
        //_slider.value = value;
        if (_mySequence != null) _mySequence.Kill();

        _mySequence = DOTween.Sequence();

        _mySequence.Append(_canvasGroup.DOFade(1, 0.1f).SetUpdate(true))
        .Append(_slider.DOValue(value, 0.5f).SetUpdate(true))
        .Append(_canvasGroup.DOFade(0, 0.5f).SetDelay(0.5f).SetUpdate(true))
        .OnComplete(() => {
            //Debug.Log("Done");
        });
    }

    public void SetHealth(int health,int maxHealth)
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        SetValue((0f + health) / maxHealth);
    }
}
