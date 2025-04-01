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

    public Vector2 MoveInput { get; private set; }

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

        _currentActionMap["Move"].performed      += OnMove;
        _currentActionMap["Jump"].performed      += OnJump;
        _currentActionMap["PushGlove"].performed += OnPushGlove;
        _currentActionMap["PullGlove"].performed += OnPullGlove;
    }

    private void OnDisable()
    {
        _currentActionMap?.Disable();
        _currentActionMap = null;
    }
    float moveDir;
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        moveDir = MoveInput.x;
    }

    private void Update()
    {

        transform.Translate(new Vector3(moveDir * _player.MoveSpeed * Time.deltaTime, 0, 0));
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