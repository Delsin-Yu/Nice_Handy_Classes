using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TSVHelper
{
    public static List<string[]> Breach(this string raw)
    {
        return raw.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(x => x.Replace("\r", "").Split(new char[] { '\t' }, StringSplitOptions.None)).ToList();
    }

    public static T As<T>(this string raw, Func<string, T> stringParser) => stringParser(raw);

    public static int AsInt(this string raw) => raw.As(x => int.Parse(x));
    public static bool AsBool(this string raw) => raw.As(x => bool.Parse(x));
    public static float AsFloat(this string raw) => raw.As(x => float.Parse(x));
    public static Vector2Int AsVector2Int(this string raw)
    {
        var xy = raw.Split(',').Select(x => x.AsInt()).ToArray();
        return new Vector2Int(xy[0], xy[1]);
    }
    public static Vector2 AsVector2(this string raw)
    {
        var xy = raw.Split(',').Select(x => x.AsFloat()).ToArray();
        return new Vector2(xy[0], xy[1]);
    }
    public static Vector3 AsVector3(this string raw)
    {
        var xyz = raw.Split(',').Select(x => x.AsFloat()).ToArray();
        return new Vector3(xyz[0], xyz[1], xyz[2]);
    }

    public static int[] AsCSIntArray(this string raw) => Split(raw, ',', x => x.AsInt());

    public static Dictionary<TKey,TValue> ToDictionary<TKey,TValue>(string keys, string values, char sperator, Func<string, TKey> keyStringParser, Func<string,TValue> valueStringParser)
    {
        var parsedKeys = keys.Split(new char[] { sperator }, StringSplitOptions.RemoveEmptyEntries).Select(x => keyStringParser(x));
        var parsedValues = values.Split(new char[] { sperator }, StringSplitOptions.RemoveEmptyEntries).Select(x => valueStringParser(x));
        return parsedKeys.Zip(parsedValues, (a, b) => new KeyValuePair<TKey, TValue>(a, b)).ToDictionary(x => x.Key, x => x.Value);
    }
    public static T[] Split<T>(string raw, char sperator, Func<string, T> stringParser)
    {
        return raw.Split(new char[] { sperator }, StringSplitOptions.RemoveEmptyEntries).Select(x => stringParser(x)).ToArray();
    }

    //FunctionName\(([^\)]+)\)
}
