using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    public static Pool Instance { get; private set; }

    private Dictionary<GameObject, Queue<GameObject>> _cloneDictonary;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _cloneDictonary = new Dictionary<GameObject, Queue<GameObject>>();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public GameObject GetGameObject(GameObject prefab)
    {
        GameObject cloneObject;
        
        if (_cloneDictonary.ContainsKey(prefab) == false) 
        {
            _cloneDictonary[prefab] = new Queue<GameObject>();
        }

        cloneObject = _cloneDictonary[prefab].FirstOrDefault(x => x.activeInHierarchy == false);
        if (cloneObject == null)
        {
            cloneObject = Instantiate(prefab, gameObject.transform,false);
            //cloneObject.transform.SetParent(gameObject.transform, true);

            _cloneDictonary[prefab].Enqueue(cloneObject);
        }
        return cloneObject;
    }
}
