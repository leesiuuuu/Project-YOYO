using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (gameObject.CompareTag("Player1"))
        {
                GetComponentInParent<Player1>().jumpAble = true;
        }

        if (gameObject.CompareTag("Player2"))
        {

                GetComponentInParent<Player2>().jumpAble = true;
        }
    }
}
