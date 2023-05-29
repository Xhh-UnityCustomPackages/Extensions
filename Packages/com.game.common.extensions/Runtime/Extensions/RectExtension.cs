using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectExtension
{
    public static Rect Create(Vector2 center, Vector2 size)
    {
        Vector2 miniCorner = center - size * 0.5f;
        return new Rect(miniCorner, size);
    }

    public static void GizmosDrawRect(this Rect rect)
    {
        Vector3 vLeftTop = new Vector3(rect.xMin, 0.0f, rect.yMax);
        Vector3 vRightTop = new Vector3(rect.xMax, 0.0f, rect.yMax);
        Vector3 vLeftBottom = new Vector3(rect.xMin, 0.0f, rect.yMin);
        Vector3 vRightBottom = new Vector3(rect.xMax, 0.0f, rect.yMin);

        Gizmos.DrawLine(vLeftTop, vRightTop);
        Gizmos.DrawLine(vLeftBottom, vRightBottom);
        Gizmos.DrawLine(vLeftTop, vLeftBottom);
        Gizmos.DrawLine(vRightTop, vRightBottom);
    }
}
