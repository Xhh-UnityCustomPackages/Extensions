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

    public static Mesh CreateCubeMesh(float xSize, float ySize, float zSize)
    {
        Vector3[] GetVertices()
        {
            Vector3 vertice_0 = new Vector3(-xSize * .5f, -ySize * .5f, zSize * .5f);
            Vector3 vertice_1 = new Vector3(xSize * .5f, -ySize * .5f, zSize * .5f);
            Vector3 vertice_2 = new Vector3(xSize * .5f, -ySize * .5f, -zSize * .5f);
            Vector3 vertice_3 = new Vector3(-xSize * .5f, -ySize * .5f, -zSize * .5f);
            Vector3 vertice_4 = new Vector3(-xSize * .5f, ySize * .5f, zSize * .5f);
            Vector3 vertice_5 = new Vector3(xSize * .5f, ySize * .5f, zSize * .5f);
            Vector3 vertice_6 = new Vector3(xSize * .5f, ySize * .5f, -zSize * .5f);
            Vector3 vertice_7 = new Vector3(-xSize * .5f, ySize * .5f, -zSize * .5f);
            Vector3[] vertices = new Vector3[]
            {          
                // Bottom Polygon
                vertice_0, vertice_1, vertice_2, vertice_0,
                // Left Polygon
                vertice_7, vertice_4, vertice_0, vertice_3,
                // Front Polygon
                vertice_4, vertice_5, vertice_1, vertice_0,
                // Back Polygon
                vertice_6, vertice_7, vertice_3, vertice_2,
                // Right Polygon
                vertice_5, vertice_6, vertice_2, vertice_1,
                // Top Polygon
                vertice_7, vertice_6, vertice_5, vertice_4
            };
            return vertices;
        }

        Vector3[] GetNormals()
        {
            Vector3 up = Vector3.up;
            Vector3 down = Vector3.down;
            Vector3 front = Vector3.forward;
            Vector3 back = Vector3.back;
            Vector3 left = Vector3.left;
            Vector3 right = Vector3.right;

            Vector3[] normales = new Vector3[]
            {
                // Bottom Side Render
                down, down, down, down, 
                // LEFT Side Render
                left, left, left, left, 
                // FRONT Side Render
                front, front, front, front,
                // BACK Side Render
                back, back, back, back,
                // RIGTH Side Render
                right, right, right, right,
                // UP Side Render
                up, up, up, up
            };

            return normales;
        }

        Vector2[] GetUVsMap()
        {
            Vector2 _00_CORDINATES = new Vector2(0f, 0f);
            Vector2 _10_CORDINATES = new Vector2(1f, 0f);
            Vector2 _01_CORDINATES = new Vector2(0f, 1f);
            Vector2 _11_CORDINATES = new Vector2(1f, 1f);
            Vector2[] uvs = new Vector2[]
            {
                // Bottom
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
                // Left
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
                // Front
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
                // Back
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
                // Right
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
                // Top
                _11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
            };
            return uvs;
        }

        int[] GetTriangles()
        {
            int[] triangles = new int[]
            {
                // Cube Bottom Side Triangles
                3, 1, 0,
                3, 2, 1,    
                // Cube Left Side Triangles
                3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
                3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
                // Cube Front Side Triangles
                3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
                3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
                // Cube Back Side Triangles
                3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
                3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
                // Cube Rigth Side Triangles
                3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
                3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
                // Cube Top Side Triangles
                3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
                3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
            };
            return triangles;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = GetVertices();
        mesh.normals = GetNormals();
        mesh.uv = GetUVsMap();
        mesh.triangles = GetTriangles();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.Optimize();

        return mesh;
    }
}
