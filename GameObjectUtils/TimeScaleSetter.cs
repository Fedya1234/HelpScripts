using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSetter : MonoBehaviour
{
    [SerializeField] float _time = 0.5f;
    [SerializeField] float _defaultScale = 1f;

    private void Start()
    {
        Time.timeScale = _defaultScale;
    }
    public void Stop()
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, _time).SetUpdate(true);//.SetEase(Ease.InQuad)
    }

    public void Play()
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, _defaultScale, _time).SetUpdate(true);//.SetEase(Ease.InQuad)
    }

    public void SetScale(float timeScale)
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, timeScale, _time).SetUpdate(true);//.SetEase(Ease.InQuad)
    }
}
