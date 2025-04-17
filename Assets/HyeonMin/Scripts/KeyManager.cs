using System.Collections.Generic;
using UnityEngine;

public enum KeyAction
{
    RIGHT,
    LEFT,
    PULL,
    PUSH,
    KEYCOUNT
}

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> player1Keys = new Dictionary<KeyAction, KeyCode>();
    public static Dictionary<KeyAction, KeyCode> player2Keys = new Dictionary<KeyAction, KeyCode>();
}

public class KeyManager : MonoBehaviour
{
    // �÷��̾� 1 Ű
    KeyCode[] _player1DefaultKeys = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.D,
        KeyCode.E,
        KeyCode.R
    };

    // �÷��̾� 2 Ű
    KeyCode[] _player2DefaultKeys = new KeyCode[]
    {
        KeyCode.RightArrow,  
        KeyCode.LeftArrow,
        KeyCode.Slash,
        KeyCode.Period
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeySetting.player1Keys[KeyAction.LEFT]))
            Debug.Log("Left");
    }

    private void Start()
    {
        // �÷��̾� Ű ����
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.player1Keys.Add((KeyAction)i, _player1DefaultKeys[i]);
            KeySetting.player2Keys.Add((KeyAction)i, _player2DefaultKeys[i]);
        }
    }

    private void OnGUI()
    {
        Event keyEvnet = Event.current;

        if (keyEvnet.isKey)
        {
            KeySetting.player1Keys[0] = keyEvnet.keyCode;

            _key = -1;
        }
    }

    private int _key = -1;
    public void OnChangeKey(int num)
    {
        _key = num;
    }
}
