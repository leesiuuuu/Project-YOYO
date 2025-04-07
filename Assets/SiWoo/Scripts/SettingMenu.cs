using UnityEditor.ShaderGraph;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]
    private EventSystem _system;
    [SerializeField]
    private GameObject FirstSelectObj;

    [SerializeField]
    private Slider[] soundSlider;

    [SerializeField]
    private Button[] keyButton;

    [SerializeField]
    private Color SelectedColor;

    [SerializeField]
    //0 = 키보드 선택 모드
    //1 = 콘솔 선택 모드
    private int ControlMode;
	private void OnEnable()
	{
        soundSlider[0].value = PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 1;
        soundSlider[1].value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1;

        ControlMode = PlayerPrefs.HasKey("ControlMode") ? PlayerPrefs.GetInt("ControlMode") : 0;
        if (ControlMode == 0) SetKeyboard();
        else SetController();

        FirstSelectObj.GetComponent<Button>().Select();
		FirstSelectObj.GetComponent<MainButton>().LoadSetting();

	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    public void SetController()
    {
        ChangeButtonColor(1, true);
        ChangeButtonColor(0, false);

        ControlMode = 1;
        PlayerPrefs.SetInt("ControlMode", ControlMode);
    }
    public void SetKeyboard()
    {
        ChangeButtonColor(0, true);
        ChangeButtonColor(1, false);

        ControlMode = 0;
		PlayerPrefs.SetInt("ControlMode", ControlMode);
	}

    private void ChangeButtonColor(int btn, bool isSelect)
    {
		ColorBlock cb = keyButton[btn].colors;
		cb.normalColor = isSelect ? SelectedColor : Color.white;

		keyButton[btn].colors = cb;
	}
}
