using UnityEngine.InputSystem;
using UnityEngine;

/// <summary>
/// 키 입력에 대한 열거형입니다.
/// 
/// Left     : 왼쪽 이동 입력
/// Right    : 오른쪽 이동 입렵
/// Jump     : 점프키 입력
/// PushGlove: 미는 장갑 입력
/// PullGlove: 당기는 장갑 입력
/// </summary>
public enum KeyInput
{
    Left,
    Right,
    Jump,
    PushGlove,
    PullGlove
}

public static class KeySetting
{
    private static InputActionAsset _inputActions;

    public static void Initialize(InputActionAsset inputActions)
    {
        _inputActions = inputActions;
    }

    public static void ChangeKey(string actionName, Key newKey, bool isGamePad = false)
    {
        if (_inputActions == null)
        {
            Debug.LogError("InputAction이 없음");
            return;
        }

        string inputType = isGamePad ? "<Gamepad>" : "<Keyboard>";

        var action = _inputActions.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError($"KeySetting: {actionName}을 찾을 수 없습니다.");
            return;
        }

        action.ApplyBindingOverride($"{inputType}/{newKey.ToString()}");
        Debug.Log($"{actionName} 키가 {newKey}로 변경됨");
    }
}