using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public static class MaterialHelper
{

#if UNITY_EDITOR
    [MenuItem("CONTEXT/Material/Remove Unused Properties")]
    private static void RemoveUnusedMaterialProperties(MenuCommand menuCommand)
    {
        var material = menuCommand.context as Material;
        if (material == null) return;

        RemoveUnusedMaterialProperties(material);
    }

    static public bool RemoveUnusedMaterialProperties(Material mat)
    {
        bool removeUnused = false;
        SerializedObject so = new SerializedObject(mat);
        so.Update();

        so.FindProperty("m_InvalidKeywords")?.ClearArray();

        SerializedProperty sp = so.FindProperty("m_SavedProperties");

        sp.Next(true);
        do
        {
            if (sp.isArray == false)
                continue;

            for (int i = sp.arraySize - 1; i >= 0; --i)
            {
                var p1 = sp.GetArrayElementAtIndex(i);
                if (p1.isArray)
                {
                    for (int ii = p1.arraySize - 1; ii >= 0; --ii)
                    {
                        var p2 = p1.GetArrayElementAtIndex(ii);
                        var val = p2.FindPropertyRelative("first");
                        if (mat.HasProperty(val.stringValue) == false)
                        {
                            Debug.Log($"Material {mat.name} remove unused property : {val.stringValue}");
                            p1.DeleteArrayElementAtIndex(ii);
                            removeUnused = true;
                        }
                    }
                }
                else
                {
                    var val = p1.FindPropertyRelative("first");
                    if (mat.HasProperty(val.stringValue) == false)
                    {
                        Debug.Log($"Material {mat.name} remove unused property : {val.stringValue}");
                        sp.DeleteArrayElementAtIndex(i);
                        removeUnused = true;
                    }
                }
            }
        }
        while (sp.Next(false));
        so.ApplyModifiedProperties();
        return removeUnused;
    }

#endif
}

