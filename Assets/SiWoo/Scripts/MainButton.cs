using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainButton : MonoBehaviour, ISelectHandler
{
	public GameObject Panel;
	public Button Back;
	public Selectable LastBtns;
	public void LoadSetting()
	{
		CanvasGroup[] others = FindObjectsOfType<CanvasGroup>();
		for(int o = 0; o < others.Length; o++)
		{
			if(others[o].gameObject == Panel)
			{
				others[o].alpha = 1;
				others[o].interactable = true;
				Navigation n = Back.navigation;
				n.selectOnUp = LastBtns;
				Back.navigation = n;
				continue;
			}

			others[o].alpha = 0;
			others[o].interactable = false;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		CanvasGroup[] others = FindObjectsOfType<CanvasGroup>();
		for (int o = 0; o < others.Length; o++)
		{
			if (others[o].gameObject == Panel)
			{
				others[o].alpha = 1;
				others[o].interactable = true;
				Navigation n = Back.navigation;
				n.selectOnUp = LastBtns;
				Back.navigation = n;
				continue;
			}

			others[o].alpha = 0;
			others[o].interactable = false;
		}
	}
}
