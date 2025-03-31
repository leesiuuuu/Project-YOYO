using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
	[SerializeField]
	private Dropdown resolutionDropdown;

	[SerializeField]
	private Toggle fullScreenBtn;

	FullScreenMode fullScreenMode;

	//[SerializeField]
	private List<Resolution> resolutions = new List<Resolution>();

	[SerializeField]
	private int resolutionNum;

	private ScrollRect scrollRect;
	private void Start()
	{
		InitUI();
	}

	void InitUI()
	{
		resolutions.AddRange(Screen.resolutions);
		resolutionDropdown.options.Clear();


		int optionNum = 0;
		foreach(Resolution item in resolutions)
		{
			Dropdown.OptionData option = new Dropdown.OptionData();
			option.text = item.width + "x" + item.height + " " + (int)item.refreshRateRatio.value + "hz";
			resolutionDropdown.options.Add(option);

			if (item.width == Screen.width && item.height == Screen.height)
				resolutionDropdown.value = optionNum;
			optionNum++;
		}
		resolutionDropdown.RefreshShownValue();

		fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;

		scrollRect = resolutionDropdown.GetComponentInChildren<ScrollRect>();

		resolutionDropdown.onValueChanged.AddListener(delegate { ScrollToSelected(); });
	}

	void ScrollToSelected()
	{
		if (scrollRect == null) return;

		int selectedIndex = resolutionDropdown.value;
		int totalOption = resolutionDropdown.options.Count;

		if (totalOption <= 1) return;

		float scrollPos = 1f - ((float)selectedIndex / (totalOption - 1));

		scrollRect.verticalNormalizedPosition = scrollPos;
	}

	public void DropboxOptionChange(int x)
	{
		resolutionNum = x;
	}

	public void FullScreenBtn(bool isFull)
	{
		fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
	}

	public void SetScreenSize()
	{
		Screen.SetResolution(resolutions[resolutionNum].width,
			resolutions[resolutionNum].height,
			fullScreenMode);
	}
}
