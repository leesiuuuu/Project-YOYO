using UnityEngine.InputSystem;
using UnityEngine;

/// <summary>
/// 
/// 키 입력에 대한 열거형입니다.
/// 
/// 코드 설명:
/// Left     : 왼쪽 이동 입력
/// Right    : 오른쪽 이동 입렵
/// Jump     : 점프키 입력
/// PushGlove: 미는 장갑 입력
/// PullGlove: 당기는 장갑 입력
/// 
/// </summary>
public enum KeyInput
{
    Left,
    Right,
    Jump,
    PushGlove,
    PullGlove
}

/// <summary>
/// 
/// 키 설정을 관리하는 클래스입니다.
/// 키 바인딩을 초기화하고 변경할 수 있는 기능을 제공합니다.
/// 
/// 코드 설명:
/// _inputActions : InputActionAsset을 저장하는 변수
/// 
/// Initialize()  : _inputActions를 초기화합니다.
/// ChangeKey()   : newKey로 키 바인딩을 변경합니다.
/// 
/// </summary>
public static class KeySetting
{
    private static InputActionAsset _inputActions;

    public static void Initialize(InputActionAsset inputActions)
    {
        // _inputActions 초기화
        _inputActions = inputActions;
    }

    public static void ChangeKey(string actionName, Key newKey, bool isGamePad = false)
    {
        // _inputActions가 null이면 에러 메시지 출력 후 종료
        if (_inputActions == null)
        {
            Debug.LogError("InputAction이 없음");
            return;
        }

        // isGamePad이 true이면 "<Gamepad>", false이면 "<Keyboard>"로 설정
        string inputType = isGamePad ? "<Gamepad>" : "<Keyboard>";

        // actionName에 해당하는 InputAction을 찾아서 action에 저장
        var action = _inputActions.FindAction(actionName);

        // action이 null이면 에러 메시지 출력 후 종료
        if (action == null)
        {
            Debug.LogError($"KeySetting: {actionName}을 찾을 수 없습니다.");
            return;
        }

        // action의 바인딩을 newKey로 변경
        action.ApplyBindingOverride($"{inputType}/{newKey.ToString()}");
        Debug.Log($"{actionName} 키가 {newKey}로 변경됨");
    }
}