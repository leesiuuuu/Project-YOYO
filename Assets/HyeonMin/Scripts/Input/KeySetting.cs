using UnityEngine.InputSystem;
using UnityEngine;

/// <summary>
/// Ű �Է¿� ���� �������Դϴ�.
/// 
/// Left     : ���� �̵� �Է�
/// Right    : ������ �̵� �Է�
/// Jump     : ����Ű �Է�
/// PushGlove: �̴� �尩 �Է�
/// PullGlove: ���� �尩 �Է�
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
            Debug.LogError("InputAction�� ����");
            return;
        }

        string inputType = isGamePad ? "<Gamepad>" : "<Keyboard>";

        var action = _inputActions.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError($"KeySetting: {actionName}�� ã�� �� �����ϴ�.");
            return;
        }

        action.ApplyBindingOverride($"{inputType}/{newKey.ToString()}");
        Debug.Log($"{actionName} Ű�� {newKey}�� �����");
    }
}