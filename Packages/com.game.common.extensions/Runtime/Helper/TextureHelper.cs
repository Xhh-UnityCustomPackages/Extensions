using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class TextureHelper
{
    public static Texture2D CopyFromRenderTexture(RenderTexture rt)
    {
        var previousRT = RenderTexture.active;
        RenderTexture.active = rt;
        TextureFormat textureFormat;
        switch (rt.format)
        {
            case RenderTextureFormat.R16: textureFormat = TextureFormat.R16; break;
            case RenderTextureFormat.R8: textureFormat = TextureFormat.R8; break;
            default: textureFormat = TextureFormat.RGBA32; break;
        }
        Texture2D tex = new Texture2D(rt.width, rt.height, textureFormat, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply(true);

        RenderTexture.active = previousRT;
        return tex;
    }

    public static Texture2D CopyFromTexture2D(Texture2D origin)
    {
        if (origin == null)
        {
            throw new System.NullReferenceException();
        }
        Texture2D tex = new Texture2D(origin.width, origin.height, origin.format, origin.mipmapCount > 1);
        tex.LoadRawTextureData(origin.GetRawTextureData());
        tex.Apply();
        return tex;
    }

#if UNITY_EDITOR
    public static void SaveFromRenderTexture(RenderTexture rt, string path)
    {
        var tex = CopyFromRenderTexture(rt);
        byte[] bytes = tex.EncodeToPNG();


        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        fs.Write(bytes, 0, bytes.Length);
        fs.Dispose();
        fs.Close();

        Debug.Log($"Save Texture at:{path} ok");

        AssetDatabase.Refresh();
    }
#endif
}
