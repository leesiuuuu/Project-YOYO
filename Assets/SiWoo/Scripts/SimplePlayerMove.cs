using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlayerMove : MonoBehaviourPunCallbacks
{
	public PhotonView PV;
	public SpriteRenderer SR;
	public Rigidbody2D RB;
	public Text Name;
	public GameObject Camera;
	public GameObject cine;
	private bool isGround = false;

	private bool isJump = false;

	private float axis = 0f;

	private void Start()
	{
		if (PV.IsMine)
		{
			Camera.SetActive(true);
			cine.SetActive(true);
			Name.color = Color.cyan;
			PV.RPC("SetNickName", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.NickName);
		}
	}

	[PunRPC]
	void SetNickName(string nick)
	{
		Name.text = nick;
	}

	void Update()
	{
		if (PV.IsMine)
		{
			axis = Input.GetAxisRaw("Horizontal");
			
			if (axis != 0) PV.RPC("FlipRPC", RpcTarget.AllBuffered, axis);

			isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -1f), 0.07f, 1 << LayerMask.NameToLayer("Ground"));
			if (Input.GetKeyDown(KeyCode.UpArrow) && isGround) PV.RPC("Jump", RpcTarget.All, 800f);
		}
	}
	void FixedUpdate()
	{
		RB.velocity = new Vector2(7 * axis, RB.velocity.y);
	}

	[PunRPC]
	void FlipRPC(float axis)
	{
		SR.flipX = axis == -1;
	}

	[PunRPC]
	void Jump(float power)
	{
		RB.velocity = Vector2.zero;
		RB.AddForce(Vector2.up * power);
	}

}
