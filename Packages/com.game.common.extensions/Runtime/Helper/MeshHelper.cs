using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshHelper
{
    public static Mesh CreateGridMesh(int xSize, int ySize, float gridSize, bool needUV = false)
    {
        Mesh mesh = new Mesh();
        var vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector4[] tangents = new Vector4[vertices.Length];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
        Vector2[] uvs = null;

        if (needUV) uvs = new Vector2[vertices.Length];

        Vector3 centerPos = new Vector3(xSize * gridSize * 0.5f, 0, ySize * gridSize * 0.5f);

        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x * gridSize, 0, y * gridSize) - centerPos;
                tangents[i] = tangent;
                if (needUV) uvs[i] = new Vector2((float)x / xSize, (float)y / ySize);
            }
        }

        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.tangents = tangents;
        if (needUV) mesh.uv = uvs;
        mesh.name = "Procedural Grid";
        mesh.RecalculateNormals();
        return mesh;
    }
}
