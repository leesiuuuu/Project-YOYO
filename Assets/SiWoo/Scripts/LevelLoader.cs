using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	public void LoadNextLevel(int SceneIndex)
	{
		StartCoroutine(LoadLevel(
			SceneManager.GetActiveScene().buildIndex + 1));
	}
	public void LoadScene(string name)
	{
		StartCoroutine(LoadLevel(name));
	}
	IEnumerator LoadLevel(int levelIndex)
	{
		animator.SetTrigger("Start");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene(levelIndex);
	}

	IEnumerator LoadLevel(string name)
	{
		animator.SetTrigger("Start");

		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene(name);
	}
}
