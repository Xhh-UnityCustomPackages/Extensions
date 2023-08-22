using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComputeShaderHelper
{

    public static int GetStride<T>()
    {
        return System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
    }

    public static void CreateComputeBuffer(ref ComputeBuffer buffer, int count, int stride, ComputeBufferType type)
    {
        bool createNewBuffer = buffer == null || !buffer.IsValid() || buffer.count != count || buffer.stride != stride;
        if (createNewBuffer)
        {
            Release(buffer);
            buffer = new ComputeBuffer(count, stride, type);
        }
    }

    public static void CreateComputeBuffer<T>(ref ComputeBuffer buffer, int count, ComputeBufferType type)
    {
        CreateComputeBuffer(ref buffer, count, GetStride<T>(), type);
    }


    public static void CreateArgsBuffer(ref ComputeBuffer buffer, int count)
    {
        int stride = count * sizeof(uint);
        CreateComputeBuffer(ref buffer, count, stride, ComputeBufferType.IndirectArguments);
    }


    public static void CreateStructuredBuffer<T>(ref ComputeBuffer buffer, int count)
    {
        CreateComputeBuffer<T>(ref buffer, count, ComputeBufferType.Structured);
    }

    public static void CreateStructuredBuffer<T>(ref ComputeBuffer buffer, T[] data)
    {
        CreateStructuredBuffer<T>(ref buffer, data.Length);
        buffer.SetData(data);
    }


    public static ComputeBuffer CreateAndSetBuffer<T>(T[] data, ComputeShader cs, string nameID, int kernelIndex = 0)
    {
        ComputeBuffer buffer = null;
        CreateAndSetBuffer<T>(ref buffer, data, cs, nameID, kernelIndex);
        return buffer;
    }

    public static void CreateAndSetBuffer<T>(ref ComputeBuffer buffer, T[] data, ComputeShader cs, string nameID, int kernelIndex = 0)
    {
        int stride = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
        CreateStructuredBuffer<T>(ref buffer, data.Length);
        buffer.SetData(data);
        cs.SetBuffer(kernelIndex, nameID, buffer);
    }

    public static void CreateAndSetBuffer<T>(ref ComputeBuffer buffer, int length, ComputeShader cs, string nameID, int kernelIndex = 0)
    {
        CreateStructuredBuffer<T>(ref buffer, length);
        cs.SetBuffer(kernelIndex, nameID, buffer);
    }

    public static ComputeBuffer CreateAndSetBuffer<T>(int length, ComputeShader cs, string nameID, int kernelIndex = 0)
    {
        ComputeBuffer buffer = null;
        CreateAndSetBuffer<T>(ref buffer, length, cs, nameID, kernelIndex);
        return buffer;
    }


    public static Vector3Int GetThreadGroupSizes(ComputeShader compute, int kernelIndex = 0)
    {
        uint x, y, z;
        compute.GetKernelThreadGroupSizes(kernelIndex, out x, out y, out z);
        return new Vector3Int((int)x, (int)y, (int)z);
    }


    public static void Release(params ComputeBuffer[] buffers)
    {
        for (int i = 0; i < buffers.Length; i++)
        {
            if (buffers[i] != null)
            {
                buffers[i].Release();
            }
        }
    }

}
