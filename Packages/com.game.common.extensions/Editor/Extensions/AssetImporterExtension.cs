using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static partial class AssetImporterExtensions
{
    public static void CopyTo(this TextureImporter textureImporter, TextureImporter targetImporter)
    {
        targetImporter.mipmapEnabled = textureImporter.mipmapEnabled;
        targetImporter.mipMapBias = textureImporter.mipMapBias;
        targetImporter.sRGBTexture = textureImporter.sRGBTexture;
        targetImporter.compressionQuality = textureImporter.compressionQuality;
        targetImporter.isReadable = textureImporter.isReadable;
        targetImporter.wrapMode = textureImporter.wrapMode;
        targetImporter.alphaSource = textureImporter.alphaSource;
        targetImporter.alphaIsTransparency = textureImporter.alphaIsTransparency;
        targetImporter.filterMode = textureImporter.filterMode;

        var originDefaultSetting = textureImporter.GetDefaultPlatformTextureSettings();
        var originAndroidSetting = textureImporter.GetPlatformTextureSettings("Android");
        var originiPhoneSetting = textureImporter.GetPlatformTextureSettings("iPhone");
        var originStandaloneSetting = textureImporter.GetPlatformTextureSettings("Standalone");


        var targetDefaultSetting = targetImporter.GetDefaultPlatformTextureSettings();
        var targetAndroidSetting = targetImporter.GetPlatformTextureSettings("Android");
        var targetiPhoneSetting = targetImporter.GetPlatformTextureSettings("iPhone");
        var targetStandaloneSetting = targetImporter.GetPlatformTextureSettings("Standalone");

        originDefaultSetting.CopyTo(targetDefaultSetting);
        originAndroidSetting.CopyTo(targetAndroidSetting);
        originiPhoneSetting.CopyTo(targetiPhoneSetting);
        originStandaloneSetting.CopyTo(targetStandaloneSetting);

        // targetImporter.SaveAndReimport();
    }

    public static void CopyTo(this ModelImporter modelImporter, ModelImporter targetImporter)
    {
        targetImporter.animationCompression = modelImporter.animationCompression;
        targetImporter.animationType = modelImporter.animationType;
        targetImporter.isReadable = modelImporter.isReadable;
        targetImporter.sortHierarchyByName = modelImporter.sortHierarchyByName;
        targetImporter.animationWrapMode = modelImporter.animationWrapMode;
        targetImporter.optimizeMeshPolygons = modelImporter.optimizeMeshPolygons;


        // targetImporter.SaveAndReimport();
    }

    public static void CopyTo(this AudioImporter audioImporter, AudioImporter targetImporter)
    {
        targetImporter.ambisonic = audioImporter.ambisonic;
        targetImporter.forceToMono = audioImporter.forceToMono;

        var originnDefaultSetting = audioImporter.defaultSampleSettings;
        var targetDefaultSetting = targetImporter.defaultSampleSettings;

        targetDefaultSetting.compressionFormat = originnDefaultSetting.compressionFormat;
        targetDefaultSetting.sampleRateOverride = originnDefaultSetting.sampleRateOverride;
        targetDefaultSetting.conversionMode = originnDefaultSetting.conversionMode;
        targetDefaultSetting.loadType = originnDefaultSetting.loadType;
        targetDefaultSetting.quality = originnDefaultSetting.quality;

        // targetImporter.SaveAndReimport();
    }
}
