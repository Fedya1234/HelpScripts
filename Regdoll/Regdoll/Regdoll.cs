using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Regdoll : MonoBehaviour
{
    List<Rigidbody> _rigidbodys;
    Animator _animator;
    List<RegdollPart> _parts;
    [SerializeField] Material _deathMaterial;
    [SerializeField] UnityEvent _eventRegdoll;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbodys = GetComponentsInChildren<Rigidbody>().ToList();

        _parts = GetComponentsInChildren<RegdollPart>().ToList();
        
    }
    private void Start()
    {
        _animator.enabled = true;
        _rigidbodys.ForEach(n => n.isKinematic = true);
    }

    private void OnEnable()
    {
        _parts.ForEach(n => n.EventHit.AddListener(MakeRegdoll));
    }
    private void OnDisable()
    {
        _parts.ForEach(n => n.EventHit.RemoveListener(MakeRegdoll));
    }

    public void MakeRegdoll()
    {
        _animator.enabled = false;
        _rigidbodys.ForEach(n => n.isKinematic = false);

        if (_deathMaterial != null)
        {
            GetComponentsInChildren<Renderer>().ToList().ForEach(n => n.sharedMaterial = _deathMaterial);
        }

        _eventRegdoll?.Invoke();
        Destroy(this);
    }

    public void AddForce(Vector3 force)
    {
        foreach (var body in _rigidbodys)
        {
            body.AddForce(force, ForceMode.Impulse);
        }
    }
    public void SetBool(string boolName, bool value)
    {
        _animator.SetBool(boolName, value);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void ResetTrigger(string triggerName)
    {
        _animator.ResetTrigger(triggerName);
    }

    public void SetFloat(string floatName, int pos)
    {
        _animator.SetFloat(floatName, pos);
    }
    public void SetFloat(string floatName, float pos)
    {
        _animator.SetFloat(floatName, pos);
    }
}
