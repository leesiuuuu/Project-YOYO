using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneScript : MonoBehaviour
{
	[SerializeField]
	private LevelLoader levelLoader;
	[SerializeField]
	private BGMScript bs;
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			bs.FadeOut();
			levelLoader.LoadScene("Main");
		}
	}
}
