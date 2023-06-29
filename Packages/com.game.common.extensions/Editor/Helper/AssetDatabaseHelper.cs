using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
    public static class AssetDatabaseHelper
    {
        public static TType LoadAssetAtGUID<TType>(string guid) where TType : UnityEngine.Object
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            return AssetDatabase.LoadAssetAtPath<TType>(path);
        }
    }
}
