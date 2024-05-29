using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static partial class AssetImporterExtensions
{
    public static void CopyTo(this TextureImporter textureImporter, TextureImporter targetImporter)
    {
        EditorUtility.CopySerialized(textureImporter, targetImporter);

        // targetImporter.SaveAndReimport();
    }

    public static void CopyTo(this ModelImporter modelImporter, ModelImporter targetImporter)
    {
        EditorUtility.CopySerialized(modelImporter, targetImporter);


        // targetImporter.SaveAndReimport();
    }

    public static void CopyTo(this AudioImporter audioImporter, AudioImporter targetImporter)
    {
        EditorUtility.CopySerialized(audioImporter, targetImporter);

        // targetImporter.SaveAndReimport();
    }
}
