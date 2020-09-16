using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    [SerializeField] GameObject[] _managers;
    /*
    private SoundManager _soundManager;
    public SoundManager SoundManager {
        get {
            if (_soundManager == null)
            {
                GameObject go = new GameObject("SoundManager");
                _soundManager = new SoundManager();
                _soundManager = go.AddComponent<SoundManager>();
            }
            return _soundManager;
        }
        private set => _soundManager = value;
    }
    */
    private void Awake()
    {
        if (Instance == null)
        {
            for (int i = 0; i < _managers.Length; i++)
            {
                Instantiate(_managers[i], transform);
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
