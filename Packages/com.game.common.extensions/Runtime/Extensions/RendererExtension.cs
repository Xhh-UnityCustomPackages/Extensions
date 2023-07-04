using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class RendererExtension
{
    private static List<Material> _Materials = new(10);

    // 会因为使用闭包而产生GC 使用此方法如何避免GC 
    // 1. 定义一个action 并初始化完毕 传入这个action
    // 2. 使用static方法 ()=>{staticMethod}
    public static void IterateMaterials(this Renderer self, Action<Material> action)
    {
        self.GetMaterials(_Materials);
        foreach (var material in _Materials)
        {
            action(material);
        }
    }
}
