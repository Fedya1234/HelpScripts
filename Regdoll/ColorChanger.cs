using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Material _newMaterial;
    Material _defaultColor;
    
    Renderer _renderer;
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _defaultColor = _renderer.sharedMaterial;
    }

    public void Execute()
    {
        _renderer.sharedMaterial = _newMaterial;
    }

    public void UnDo()
    {
        _renderer.sharedMaterial = _defaultColor;
    }
}
