using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			LoadNextLevel(0, true);
		}
	}
	public void LoadNextLevel(int SceneIndex, bool NextLevelLoader = false)
	{
		StartCoroutine(LoadLevel(
			NextLevelLoader ? SceneManager.GetActiveScene().buildIndex + 1 : SceneIndex));
	}
	IEnumerator LoadLevel(int levelIndex)
	{
		animator.SetTrigger("Start");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene(levelIndex);
	}
}
