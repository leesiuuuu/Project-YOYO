using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    [SerializeField]
    private List<Key> _keys = new List<Key>();

    public static int KeyCount { get; private set; } = 0;
    private static int _maxCount = 0;

    private void Awake()
    {
        Key[] currentKeys = FindObjectsOfType<Key>();

        foreach (var key in currentKeys)
        {
            _keys.Add(key);
        }
        _maxCount = _keys.Count;
    }

    public static void AddCount(int amount = 1)
    {
        if (KeyCount + amount <= _maxCount)
            KeyCount += amount;

        Debug.Log(KeyCount);
    }

    public static void ResetCount()
    {
        KeyCount = 0;
        _maxCount = 0;
    }
}
