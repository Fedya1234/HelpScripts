using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

[System.Serializable]
public struct SoundStructure
{
    public SoundName Name;
    public AudioSource AudioClip;
}

[System.Serializable]
public class PitchSound
{
    public SoundName Name;
    public float Time = 0.2f;
    public float Step = 0.1f;
    public float Pitch;
    public float MinPitch;
    public Tween Tween;
}

[System.Serializable]
public enum SoundName
{
    COIN,
    WIN,
    LOSE,
    BUY,
    BLOW,
    KONFETY,
    FIREWORK,
    BOSS,
    EATING,
    KEY,
    FALL,
    UPGRADE,
    BOSS_HIT,
    COLOR_CHANGE
}

public class SoundManager : BaseManager<SoundManager>
{
    [SerializeField] List<SoundStructure> _soundsList;
    [SerializeField] List<PitchSound> _pitchList;
    [SerializeField] AudioSource _loopSound;
    const float MAX_PITCH = 3;

    private void Start()
    {
        for (int i = 0; i < _pitchList.Count; i++)
        {
            if (_soundsList.Select(n => n.Name).Contains(_pitchList[i].Name))
            {
                SoundStructure pSound = _soundsList.First(n => n.Name == _pitchList[i].Name);
                _pitchList[i].Pitch = pSound.AudioClip.pitch;
                _pitchList[i].MinPitch = _pitchList[i].Pitch;
            }
        }
    }

    public void PlaySound(SoundName sound)
    {
        AudioSource audioClip = _soundsList.Find(str => str.Name == sound).AudioClip;
        if (_pitchList.Select(n => n.Name).Contains(sound))
        {
            PitchSound pSound = _pitchList.First(n => n.Name == sound);
            audioClip.pitch = pSound.Pitch;
            pSound.Pitch += pSound.Step;
            pSound.Pitch = Mathf.Clamp(pSound.Pitch, pSound.MinPitch, MAX_PITCH);
            pSound.Tween?.Kill();
            pSound.Tween = DOVirtual.DelayedCall(pSound.Time, () => { pSound.Pitch = pSound.MinPitch; });
        }
        
        audioClip.Play();
    }
    public void PlayLoopSound()
    {
        _loopSound.Play();
    }
    public void StopLoopSound()
    {
        _loopSound.Stop();
    }
}
