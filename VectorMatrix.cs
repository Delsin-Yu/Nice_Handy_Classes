using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorMatrix
{
    public static Vector2 Matrix(Func<float, float, float> operation, Vector2 a, Vector2 b)
    {
        return new Vector2(operation(a.x, b.x), operation(a.y, b.y));
    }
    public static Vector3 Matrix(Func<float, float, float> operation, Vector3 a, Vector3 b)
    {
        return new Vector3(operation(a.x, b.x), operation(a.y, b.y), operation(a.z, b.z));
    }

    public static bool Matrix(Func<float, float, bool> operation, Vector2 a, Vector2 b)
    {
        return operation(a.x, b.x) && operation(a.y, b.y);
    }
    public static bool Matrix(Func<float, float, bool> operation, Vector3 a, Vector3 b)
    {
        return operation(a.x, b.x) && operation(a.y, b.y) && operation(a.z, b.z);
    }

    public static Vector2 Matrix(Func<float, float> operation, Vector2 a)
    {
        return new Vector2(operation(a.x), operation(a.y));
    }
    public static Vector3 Matrix(Func<float, float> operation, Vector3 a)
    {
        return new Vector3(operation(a.x), operation(a.y), operation(a.z));
    }

    public static bool Matrix(Func<float, bool> operation, Vector2 a, Vector2 b)
    {
        return operation(a.x) && operation(a.y);
    }
    public static bool Matrix(Func<float, bool> operation, Vector3 a)
    {
        return operation(a.x) && operation(a.y) && operation(a.z);
    }
}
