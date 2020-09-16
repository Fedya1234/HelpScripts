using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    private const float DOT_RANGE = 0.5f;
    public static bool IsFacingTarget(this Transform transform, Transform target)
    {
        var vectorToTarget = transform.position - target.position;
        vectorToTarget.Normalize();
        float dot = Vector3.Dot(transform.forward, vectorToTarget);
        return dot >= DOT_RANGE;
    }
}
