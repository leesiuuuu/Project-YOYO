using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NicknameInput : MonoBehaviour
{
	public InputField NickInput;
	public GameObject btn;

	public void Update()
	{
		if(NickInput.text.Length > 0)
		{
			btn.SetActive(true);
		}
		else
		{
			btn.SetActive(false);
		}
	}
	public void SubmitNickname()
	{
		PhotonNetwork.NickName = NickInput.text;
		PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
		gameObject.SetActive(false);
	}
}
