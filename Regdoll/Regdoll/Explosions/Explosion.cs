using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] float _force;
    [SerializeField] float _upwards=0.1f;
    [SerializeField] Vector3 _offset = new Vector3();
    [SerializeField] float _killRadius;

    public void Execute()
    {
        AddForce(transform.position);
    }


    void AddForce(Vector3 point)
    {
        Collider[] colliders = Physics.OverlapSphere(point, _killRadius);
        foreach (Collider hit in colliders)
        {
            RegdollPart regdollPart = hit.transform.GetComponent<RegdollPart>();
            if (regdollPart != null)
            {
                regdollPart.OnHit();
            }
            TimedExplosionEvent timedEvent = hit.transform.GetComponent<TimedExplosionEvent>();
            if (timedEvent != null)
            {
                timedEvent.Execute();
            }
        }

        colliders = Physics.OverlapSphere(point, _radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_force, point + _offset, _radius, _upwards);
            }
        }
    }

}