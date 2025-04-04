using UnityEngine;
using UnityEngine.EventSystems;

public class MainButton : MonoBehaviour, ISelectHandler
{
	public GameObject Panel;
	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		CanvasGroup[] others = FindObjectsOfType<CanvasGroup>();
		for(int o = 0; o < others.Length; o++)
		{
			if(others[o].gameObject == Panel)
			{
				others[o].alpha = 1;
				continue;
			}

			others[o].alpha = 0;
		}
	}
}
