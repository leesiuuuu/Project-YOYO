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

	private void OnEnable()
	{
        FirstSelectObj.GetComponent<Button>().Select();
        soundSlider[0].value = PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 1;
        soundSlider[1].value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1;
	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
