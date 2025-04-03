using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private static SoundManager instance;

	public static SoundManager Instance
	{
		get
		{
			if(instance == null) instance = new SoundManager();
			return instance;
		}
	}
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
