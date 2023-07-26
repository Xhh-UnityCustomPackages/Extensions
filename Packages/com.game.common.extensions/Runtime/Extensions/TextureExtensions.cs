using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureExtensions
{
    /// <summary>
    /// Draw a GUI texture
    /// </summary>
    public static void DrawGUI(this Texture tex, float xOffset, float yOffset)
    {
        GUI.DrawTexture(new Rect(xOffset, yOffset, tex.width, tex.height), tex);
    }
}
