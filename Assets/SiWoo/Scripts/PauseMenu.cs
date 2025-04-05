using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public GameObject SettingPrefab;
	private bool isSettingMenu;

	[SerializeField]
	private Button SettingButton;

	public void ActiveSetting()
	{
		SettingPrefab.SetActive(true);
		isSettingMenu = true;
	}
	private void Update()
	{
		if (!SettingPrefab.activeSelf && isSettingMenu)
		{
			SettingButton.Select();
			isSettingMenu = false;
		}
	}
}
