using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector2 xy(this Vector3 v) => new Vector2(v.x, v.y);
    public static Vector2 xz(this Vector3 v) => new Vector2(v.x, v.z);
    public static Vector2 yz(this Vector3 v) => new Vector2(v.y, v.z);
    public static Vector2 yx(this Vector3 v) => new Vector2(v.y, v.x);
    public static Vector2 zx(this Vector3 v) => new Vector2(v.z, v.x);
    public static Vector2 zy(this Vector3 v) => new Vector2(v.z, v.y);
}
