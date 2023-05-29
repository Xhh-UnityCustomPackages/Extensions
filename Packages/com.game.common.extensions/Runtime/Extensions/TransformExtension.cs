using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    public static T AddMissingComponent<T>(this Transform self) where T : Component
    {
        T retT = self.GetComponent<T>();
        return retT ?? self.gameObject.AddComponent<T>();
    }

    public static void Reset(this Transform self)
    {
        self.localPosition = Vector3.zero;
        self.localScale = Vector3.one;
        self.localRotation = Quaternion.identity;
    }

    public static void SetParentAndReset(this Transform trans, Transform parent)
    {
        trans.SetParent(parent, false);
        trans.Reset();
    }

    #region transform.position
    public static void SetPositionX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.position;
        vector3.x = x;
        transform.position = vector3;
    }

    public static void SetPositionY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.position;
        vector3.y = y;
        transform.position = vector3;
    }

    public static void SetPositionZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.position;
        vector3.z = z;
        transform.position = vector3;
    }

    public static void AddPositionX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.position;
        vector3.x += x;
        transform.position = vector3;
    }


    public static void AddPositionY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.position;
        vector3.y += y;
        transform.position = vector3;
    }

    public static void AddPositionZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.position;
        vector3.z += z;
        transform.position = vector3;
    }

    public static void SubPositionX(this Transform transform, float x)
    {
        transform.AddPositionX(-x);
    }

    public static void SubPositionY(this Transform transform, float y)
    {
        transform.AddPositionY(-y);
    }
    public static void SubPositionZ(this Transform transform, float z)
    {
        transform.AddPositionZ(-z);
    }
    #endregion transform.position

    #region transform.localPosition
    public static void SetLocalPositionX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.x = x;
        transform.localPosition = vector3;
    }

    public static void SetLocalPositionY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.y = y;
        transform.localPosition = vector3;
    }

    public static void SetLocalPositionZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.z = z;
        transform.localPosition = vector3;
    }

    public static void AddLocalPosition(this Transform transform, Vector3 delta)
    {
        Vector3 vector3 = transform.localPosition;
        vector3 += delta;
        transform.localPosition = vector3;
    }

    public static void AddLocalPositionX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.x += x;
        transform.localPosition = vector3;
    }


    public static void AddLocalPositionY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.y += y;
        transform.localPosition = vector3;
    }

    public static void AddLocalPositionZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.localPosition;
        vector3.z += z;
        transform.localPosition = vector3;
    }

    public static void SubLocalPositionX(this Transform transform, float x)
    {
        transform.AddLocalPositionX(-x);
    }

    public static void SubLocalPositionY(this Transform transform, float y)
    {
        transform.AddLocalPositionY(-y);
    }
    public static void SubLocalPositionZ(this Transform transform, float z)
    {
        transform.AddLocalPositionZ(-z);
    }

    #endregion transform.localPosition

    #region transform.localScale
    public static void SetLocalScaleX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localScale;
        vector3.x = x;
        transform.localScale = vector3;
    }

    public static void SetLocalScaleY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localScale;
        vector3.y = y;
        transform.localScale = vector3;
    }

    public static void SetLocalScaleZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.localScale;
        vector3.z = z;
        transform.localScale = vector3;
    }

    public static void AddLocalScaleX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localScale;
        vector3.x += x;
        transform.localScale = vector3;
    }


    public static void AddLocalScaleY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localScale;
        vector3.y += y;
        transform.localScale = vector3;
    }

    public static void AddLocalScaleZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.localScale;
        vector3.z += z;
        transform.localScale = vector3;
    }

    public static void SubLocalScaleX(this Transform transform, float x)
    {
        transform.AddLocalScaleX(-x);
    }

    public static void SubLocalScaleY(this Transform transform, float y)
    {
        transform.AddLocalScaleY(-y);
    }
    public static void SubLocalScaleZ(this Transform transform, float z)
    {
        transform.AddLocalScaleZ(-z);
    }

    #endregion transform.localScale

    #region transform.localEulerAngles
    public static void SetLocalEulerAnglesX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localEulerAngles;
        vector3.x = x;
        transform.localEulerAngles = vector3;
    }

    public static void SetLocalEulerAnglesY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localEulerAngles;
        vector3.y = y;
        transform.localEulerAngles = vector3;
    }

    public static void SetLocalEulerAnglesZ(this Transform transform, float z)
    {
        if (transform == null)
            return;

        Vector3 vector3 = transform.localEulerAngles;
        vector3.z = z;
        transform.localEulerAngles = vector3;
    }

    public static void AddLocalEulerAnglesX(this Transform transform, float x)
    {
        Vector3 vector3 = transform.localEulerAngles;
        vector3.x += x;
        transform.localEulerAngles = vector3;
    }


    public static void AddLocalEulerAnglesY(this Transform transform, float y)
    {
        Vector3 vector3 = transform.localEulerAngles;
        vector3.y += y;
        transform.localEulerAngles = vector3;
    }

    public static void AddLocalEulerAnglesZ(this Transform transform, float z)
    {
        Vector3 vector3 = transform.localEulerAngles;
        vector3.z += z;
        transform.localEulerAngles = vector3;
    }

    public static void SubLocalEulerAnglesX(this Transform transform, float x)
    {
        transform.AddLocalEulerAnglesX(-x);
    }

    public static void SubLocalEulerAnglesY(this Transform transform, float y)
    {
        transform.AddLocalEulerAnglesY(-y);
    }
    public static void SubLocalEulerAnglesZ(this Transform transform, float z)
    {
        transform.AddLocalEulerAnglesZ(-z);
    }

    #endregion transform.localEulerAngles

    public static void DestroyChildren(this Transform trans, bool immediate = false, List<string> childNameList = null)
    {
        if (trans == null)
            return;
        List<GameObject> gos = new List<GameObject>();
        foreach (Transform child in trans)
        {
            if (childNameList == null)
            {
                gos.Add(child.gameObject);
            }
            else if (childNameList.Contains(child.name))
            {
                gos.Add(child.gameObject);
            }
        }

        foreach (var go in gos)
        {
            if (immediate)
                GameObject.DestroyImmediate(go);
            else
                GameObject.Destroy(go);
        }

        return;
    }


}
