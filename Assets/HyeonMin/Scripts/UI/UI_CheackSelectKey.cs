using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2
}

public class UI_CheckSelectKey : MonoBehaviour
{
    private KeyCode _getCode = KeyCode.None;
    private bool _waitingForKey = false;
    private int _keyIndex = -1;

    private PlayerType _playerType;

    [SerializeField] private KeyManager _keyManager;

    private void OnEnable()
    {
        _waitingForKey = true;
        _getCode = KeyCode.None;
    }


    private void Update()
    {
        if (_waitingForKey)
        {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    _getCode = code;
                    _waitingForKey = false;
                    gameObject.SetActive(false);

                    if (_keyIndex != -1)
                    {
                        if (_playerType == PlayerType.Player1)
                        {
                            _keyManager.OnPlayer1ChangeKey(_getCode, _keyIndex);
                            Debug.Log($"플레이어 1 변경된 키: {_getCode}, 인덱스: {_keyIndex}");
                        }
                        else if ( _playerType == PlayerType.Player2)
                        {
                            _keyManager.OnPlayer2ChangeKey(_getCode, _keyIndex);
                            Debug.Log($"플레이어 1 변경된 키: {_getCode}, 인덱스: {_keyIndex}");
                        }
                    }

                    break;
                }
            }
        }
    }

    public void SetKeyIndex(int index)
    {
        _keyIndex = index;
    }

    public KeyCode GetSelectedKey()
    {
        return _getCode;
    }

    public void SetPlayerType(PlayerType playerType)
    {
        _playerType = playerType;
    }
}
