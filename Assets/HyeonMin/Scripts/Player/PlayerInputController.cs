using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// 플레이어의 입력을 관리하는 클래스입니다.
/// 
/// 코드 설명:
/// 
/// 
/// 
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActionAsset;
    private Player _player;

    private Vector2 _moveInput;
    public Vector2 MoveInput => _moveInput;

    [field: Header("Player Action Map"), SerializeField]
    private InputActionMap _currentActionMap;

    private void Awake()
    {
        _player = GetComponent<Player>();
        KeySetting.Initialize(_inputActionAsset);
    }

    private void Start()
    {
        Debug.Log(_player.PlayerID);

        if (_player.PlayerID == 1)
            _currentActionMap = _inputActionAsset.FindActionMap("Player_1");

        else if (_player.PlayerID == 2)
            _currentActionMap = _inputActionAsset.FindActionMap("Player_2");
        else
            Debug.Log("ID = none");

        _currentActionMap.Enable();
        Debug.Log(_currentActionMap.name);
    }

    private void OnDisable()
    {
        _currentActionMap?.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");

        }
    }

    public void OnPushGlove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PushGlove");

        }
    }

    public void OnPullGlove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PullGlove");

        }
    }
}
