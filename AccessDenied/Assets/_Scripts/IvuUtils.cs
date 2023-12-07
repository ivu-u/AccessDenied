using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IvuUtils
{
    /// <summary>
    /// Generate random normalized direction
    /// </summary>
    public static Vector3 GetRandomDir() {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
