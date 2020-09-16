using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using DG.Tweening;

public class ExplosionForce : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] float _force;
    [SerializeField] float _radius;
    [SerializeField] float _upward = 0.4f;
    [SerializeField] UnityEvent OnExplosion;

    [SerializeField] float _removeTime = 5f;
    [SerializeField] Vector3 _offSet = new Vector3(0, 0, 0);
    
    private void OnTriggerEnter(Collider other)
    {
        if (_tags.Contains(other.tag))
        {
            OnExplosion?.Invoke();

            AddForce(other.transform.position);


            Destroy(gameObject, _removeTime);
        }
    }

    void AddForce(Vector3 point)
    {
        Collider[] colliders = Physics.OverlapSphere(point, _radius);
        

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_force, point + _offSet, _radius, _upward);
            }
        }
    }
   
}
