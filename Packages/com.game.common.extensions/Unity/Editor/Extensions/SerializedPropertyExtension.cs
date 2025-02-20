using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static partial class SerializedPropertyExtension
{
    /// <summary>
    /// 获取枚举
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="property"></param>
    /// <returns></returns>
    public static T GetEnum<T>(this SerializedProperty property)
    {
        return (T)Enum.Parse(typeof(T), property.enumNames[property.enumValueIndex]);
    }


    /// <summary>
    /// 设置枚举
    /// </summary>
    /// <param name="property"></param>
    /// <param name="enumValue"></param>
    public static void SetEnum(this SerializedProperty property, Enum enumValue)
    {
        for (int i = 0; i < property.enumNames.Length; i++)
        {
            if (property.enumNames[i] == enumValue.ToString())
            {
                property.enumValueIndex = i;
                break;
            }
        }
    }
}
