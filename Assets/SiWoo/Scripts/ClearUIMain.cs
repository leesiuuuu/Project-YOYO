using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClearUIMain : MonoBehaviour
{
	public Button[] btns;
	public Button lastbtn;
	private bool isSelected = false;

	private void Update()
	{
		if (Input.anyKeyDown && !isSelected)
		{
			btns[0].Select();
			isSelected = true;
		}
	}
	public void Cancel()
	{
		isSelected = false;
		lastbtn.Select();
	}
}
