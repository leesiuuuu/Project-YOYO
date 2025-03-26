using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
	public Text StatuText;
	public InputField NickName, RoomInput;


	void Awake() => Screen.SetResolution(1920, 1080, false);

	void Update() => StatuText.text = PhotonNetwork.NetworkClientState.ToString();

	public void Connect() => PhotonNetwork.ConnectUsingSettings();

	public void Disconnect() => PhotonNetwork.Disconnect();

	public override void OnConnectedToMaster()
	{
		PhotonNetwork.LocalPlayer.NickName = NickName.text;
		Debug.Log("서버 접속 완료! 닉네임 : " + PhotonNetwork.LocalPlayer.NickName);
	}
	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.Log("접속 끊음");
	}
}
