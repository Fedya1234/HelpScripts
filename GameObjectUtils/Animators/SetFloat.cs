using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloat : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] float _value;
    [SerializeField] bool _isRandom;
    [SerializeField] Animator _animator;
    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

        if (_isRandom)
        {
            _value = Random.Range(0, _value);
        }
    }

    public void Execute()
    {
        _animator.SetFloat(_name, _value);
    }

    public void SetValue(float value)
    {
        _animator.SetFloat(_name, value);
    }
}
