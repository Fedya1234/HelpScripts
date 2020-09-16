using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IntEvent : UnityEvent<int> { }

public class HelthBar : MonoBehaviour
{
    [SerializeField] int _maxHelth;
    public UnityEvent EventDeath;
    public IntEvent EventDamage;
    int _health;

    HelthShower _helthShower;
    bool _isDead;

    void Awake()
    {
        _helthShower = GetComponentInChildren<HelthShower>();
        _health = _maxHelth;
        _isDead = false;

    }

    public void SetHealth(int health)
    {
        _maxHelth = health;
        _health = _maxHelth;
    }

    public void AddHealth(int count)
    {
        MakeDamage(-count);
    }

    public void MakeDamage(int damageCount)
    {
        if (_isDead)
        {
            return;
        }
        _health -= damageCount;

        _helthShower.SetHealth(_health, _maxHelth);

        if (_health <= 0)
        {
            EventDeath?.Invoke();
            _isDead = true;
        }
        else
        {
            EventDamage?.Invoke(damageCount);
        }
    }
}
