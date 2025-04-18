using System.Collections.Generic;
using UnityEngine;

public enum KeyAction
{
    LEFT,
    RIGHT,
    Jump,
    PUSH,
    PULL,
    KEYCOUNT
}

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> player1Keys = new Dictionary<KeyAction, KeyCode>();
    public static Dictionary<KeyAction, KeyCode> player2Keys = new Dictionary<KeyAction, KeyCode>();

    public static bool IsGamePad { get; set; } = false;
}

public class KeyManager : MonoBehaviour
{
    [field:SerializeField]
    public GameObject CheckSelectPanel { get; private set; }
    [SerializeField] private UI_CheckSelectKey _checkSelectKeyUI;

    [SerializeField]
    private KeyCode[] _player1DefaultKeys = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.D,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R
    };

    [SerializeField]
    private KeyCode[] _player2DefaultKeys = new KeyCode[]
    {
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.UpArrow,
        KeyCode.Period,
        KeyCode.Slash
    };

    private void Awake()
    {
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.player1Keys.Add((KeyAction)i, _player1DefaultKeys[i]);
            KeySetting.player2Keys.Add((KeyAction)i, _player2DefaultKeys[i]);
        }
    }

    private void Start()
    {
        CheckSelectPanel?.SetActive(false);
    }

    public void OnChangeKey(PlayerType playerType, int index)
    {
        CheckSelectPanel.SetActive(true);
        _checkSelectKeyUI.SetPlayerType(playerType);
        _checkSelectKeyUI.SetKeyIndex(index);
    }

    public void OnPlayer1ChangeKey(KeyCode newKey, int index)
    {
        KeySetting.player1Keys[(KeyAction)index] = newKey;
    }

    public void OnPlayer2ChangeKey(KeyCode newKey, int index)
    {
        KeySetting.player2Keys[(KeyAction)index] = newKey;
    }
}
