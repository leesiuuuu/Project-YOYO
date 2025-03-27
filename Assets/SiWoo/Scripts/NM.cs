using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NM : MonoBehaviourPunCallbacks
{
	public Text ping;
	public GameObject SceneCamera;
	private void Awake()
	{
		Screen.SetResolution(960, 540, false);
		PhotonNetwork.ConnectUsingSettings();
	}
	private void Update()
	{
		ping.text = PhotonNetwork.GetPing().ToString() + "ms";
	}

	public override void OnJoinedRoom()
	{
		Vector3 pos = new Vector3(Random.Range(-3f, 3f), Random.Range(0f, 3f));
		PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
		SceneCamera.SetActive(false);
	}
}
