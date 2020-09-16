using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayableDirectorHelper : MonoBehaviour
{
    public UnityEvent OnEndedEvent;


    void OnEnable()
    {
        GetComponent<PlayableDirector>().stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (GetComponent<PlayableDirector>() == aDirector)
            OnEndedEvent?.Invoke();
    }

    void OnDisable()
    {
        GetComponent<PlayableDirector>().stopped -= OnPlayableDirectorStopped;
    }
}
