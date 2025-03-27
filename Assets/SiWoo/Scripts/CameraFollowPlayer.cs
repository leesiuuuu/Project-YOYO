using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	public Transform Player;
	void LateUpdate()
	{
		if (Player == null) return;

		// 부모의 위치를 따라가되, 보간하여 부드럽게 이동
		transform.position = Vector3.Lerp(transform.localPosition, Player.position, Time.deltaTime);
	}
}
