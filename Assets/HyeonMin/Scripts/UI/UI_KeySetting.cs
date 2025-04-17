using UnityEngine;
using UnityEngine.UI;

public class UI_KeySetting : MonoBehaviour
{
    [SerializeField]
    private Text[] _currentKeys;

    private void Start()
    {
        for (int i = 0; i < _currentKeys.Length; i++)
        {
            _currentKeys[i].text = KeySetting.player1Keys[(KeyAction)i].ToString();
        }
    }

    private void Update()
    {
        for (int i = 0; i < _currentKeys.Length; i++)
        {
            _currentKeys[i].text = KeySetting.player1Keys[(KeyAction)i].ToString();
        }
    }
}