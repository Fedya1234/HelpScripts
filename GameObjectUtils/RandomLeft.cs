using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomLeft : MonoBehaviour
{
    private void Awake()
    {
        List<Transform> childList = transform.Cast<Transform>().ToList();
        childList.ToList().ForEach(n => n.gameObject.SetActive(false));
        childList[Random.Range(0, childList.Count)].gameObject.SetActive(true);
        //childList.OrderBy(n => Random.Range(0, int.MaxValue)).Skip(1).ToList().ForEach(n => Destroy(n.gameObject));

        childList.Where(n => n.gameObject.activeInHierarchy==false).ToList().ForEach(n => Destroy(n.gameObject));
    }

}
