using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct EffectStructure
{
    public EffectName Name;
    public GameObject Effect;
}

[System.Serializable]
public enum EffectName
{
    Destroy3,
    Destroy5,
    DestroyBoss,
    DestroyHead,
    Water,
    TakeKey,
    MonetsBoss,
    DestroyEffect3x3
}

public class EffectsManager : BaseManager<EffectsManager>
{
    [SerializeField] List<EffectStructure> effectsList;
    private Dictionary<EffectName, List<GameObject>> _effectsByName;

    protected override void Awake()
    {
        base.Awake();
        CreateDictionarey();
    }

    private void CreateDictionarey()
    {
        _effectsByName = new Dictionary<EffectName, List<GameObject>>();
        foreach(EffectStructure eff in effectsList)
        {
            if (_effectsByName.ContainsKey(eff.Name)==false)
            {
                _effectsByName.Add(eff.Name, new List<GameObject>());
            }
            _effectsByName[eff.Name].Add(eff.Effect);
        }

        foreach (EffectName effName in EffectName.GetValues(typeof(EffectName)))
        {
            if (_effectsByName.ContainsKey(effName) == false)
            {
                Debug.LogWarning("NO Any Effects for: " + effName.ToString());
            }
        }
    }

    public GameObject GetEffect(EffectName effect)
    {
        return _effectsByName[effect][Random.Range(0,_effectsByName[effect].Count)];
    }

    public GameObject Create(EffectName effect)
    {
        return Instantiate(GetEffect(effect));
    }

    public GameObject Create(EffectName effect, Vector3 position)
    {
        return Create(effect, position, Quaternion.identity);
    }

    public GameObject Create(EffectName effect, Vector3 position, Quaternion rotation)
    {
        return Instantiate(GetEffect(effect), position, rotation, transform);
    }
}
