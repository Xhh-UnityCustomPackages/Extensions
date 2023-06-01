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

    public static bool Approximately(this Vector4 self, Vector4 other)
    {
        return Mathf.Approximately(self.x, other.x) &&
                Mathf.Approximately(self.y, other.y) &&
                Mathf.Approximately(self.z, other.z) &&
                Mathf.Approximately(self.w, other.w);
    }

    public static bool Approximately(this Vector3 self, Vector3 other)
    {
        return Mathf.Approximately(self.x, other.x) && Mathf.Approximately(self.y, other.y) && Mathf.Approximately(self.z, other.z);
    }

    public static bool Approximately(this Vector2 self, Vector2 other)
    {
        return Mathf.Approximately(self.x, other.x) && Mathf.Approximately(self.y, other.y);
    }


}
