using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : Singletone<T>
{
    private static T instance;
    public static T Instanse => instance;

    public static bool IsInitialized => instance != null;
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("[Singletone] try to create second One type = " + typeof(T));
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this) instance = null;
    }
}
