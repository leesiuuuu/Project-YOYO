using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJoyNumIndex : MonoBehaviour
{
    private void Start()
    {
        string[] currentJoyNumNames = Input.GetJoystickNames();
        for (int i = 0; i < currentJoyNumNames.Length; i++)
        {
            if (!string.IsNullOrEmpty(currentJoyNumNames[i]))
            {
                Debug.Log($"[{i}] ����� ���̽�ƽ: {currentJoyNumNames[i]}");
            }
            else
            {
                Debug.Log($"[{i}] ����ִ� ����");
            }
        }
    }
}
