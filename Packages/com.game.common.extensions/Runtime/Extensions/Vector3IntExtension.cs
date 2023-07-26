using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Vector3IntExtension
{
    public static Vector3 ToVector3(this Vector3Int vector)
    {
        return new Vector3(
            Convert.ToSingle(vector.x),
            Convert.ToSingle(vector.y),
            Convert.ToSingle(vector.z)
        );
    }
}
