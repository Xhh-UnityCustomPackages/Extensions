using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuaternionExtension
{
    public static bool Approximately(this Quaternion self, Quaternion other)
    {
        return Mathf.Approximately(self.x, other.x)
            && Mathf.Approximately(self.y, other.y)
            && Mathf.Approximately(self.z, other.z)
            && Mathf.Approximately(self.w, other.w);
    }
}
