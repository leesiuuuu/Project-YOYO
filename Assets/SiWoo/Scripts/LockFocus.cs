using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LockFocus : MonoBehaviour
{
	private GameObject defaultSelected;
	
	void Update()
	{
		// 선택 상태 유지
		if (!EventSystem.current.currentSelectedGameObject)
		{
			EventSystem.current.SetSelectedGameObject(defaultSelected);
		}
		defaultSelected = EventSystem.current.currentSelectedGameObject;
	}
}