using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NM : MonoBehaviourPunCallbacks
{
	public Text ping;
	private void Awake()
	{
		Screen.SetResolution(960, 540, false);
		PhotonNetwork.ConnectUsingSettings();
	}
	public override void OnConnectedToMaster()
	{
		PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
	}
	private void Update()
	{
		ping.text = PhotonNetwork.GetPing().ToString() + "ms";
	}

	public override void OnJoinedRoom()
	{
		Vector3 pos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
		PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
	}
}
