using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
	private static SoundManager instance;

	public AudioSource bgSound;
	public AudioMixer audioMixer;
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
	public void SFXPlay(string sfxName, AudioClip clip)
	{
		GameObject go = new GameObject(sfxName + "Sound");
		AudioSource source = go.AddComponent<AudioSource>();
		source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
		source.clip = clip;
		source.Play();

		Destroy(go, clip.length);
	}
	public void BgSoundPlay(AudioClip clip)
	{
		bgSound.clip = clip;
		bgSound.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Music")[0];
		bgSound.loop = true;
		bgSound.volume = 0.1f;
		bgSound.Play();
	}
	public void BGSoundVolume(float val)
	{
		audioMixer.SetFloat("MusicVolume", Mathf.Log10(val) * 20);
	}
	public void SFXSoundVolume(float val)
	{
		audioMixer.SetFloat("SFXVolume", Mathf.Log10(val) * 20);
	}
}
