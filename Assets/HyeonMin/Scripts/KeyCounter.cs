using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    [SerializeField]
    private List<Key> _keys = new List<Key>();

    private static int _keyCount = 0;
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
        if (_keyCount + amount <= _maxCount)
            _keyCount += amount;

        Debug.Log(_keyCount);
    }

    public static void ResetCount()
    {
        _keyCount = 0;
        _maxCount = 0;
    }
}
