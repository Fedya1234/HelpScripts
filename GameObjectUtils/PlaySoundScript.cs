using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SoundPlayer;
public class PlaySoundScript : MonoBehaviour
{
    [SerializeField] SoundName _sound;

    public void Execute()
    {
        SoundManager.Instance.PlaySound(_sound);
    }
}
