using System.Collections;
using UnityEngine;

public class CreditMove : MonoBehaviour
{
	bool isMove = true;
	public LevelLoader LevelLoader;
	private void Start()
	{
		StartCoroutine(MoveCredit());
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			LevelLoader.LoadScene("SelectScene");
		}
	}
	IEnumerator MoveCredit()
	{
		yield return new WaitForSeconds(3f);
		float timer = 0f;
		float duration = 30f;
		Vector2 start = new Vector2(0, 0);
		Vector2 end = new Vector2(0, 5400);
		RectTransform rt = GetComponent<RectTransform>();

		while (timer < duration)
		{
			timer += Time.deltaTime;
			float t = Mathf.Clamp01(timer / duration);
			rt.anchoredPosition = Vector2.Lerp(start, end, t);
			yield return null;
		}

		rt.anchoredPosition = end;
		yield return new WaitForSeconds(3f);
		LevelLoader.LoadScene("SelectScene");
	}
}
