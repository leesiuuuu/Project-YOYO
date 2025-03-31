using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    Player2 player;
    Transform player1;

    public bool setPosing;

    private void Awake()
    {
        player = GetComponentInParent<Player2>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
    }

    private void Start()
    {
        setPosing = false;
    }

    private void Update()
    {
        if (setPosing)
        {
            player1.transform.position = gameObject.transform.position;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            if (player.Grab)
            {
                setPosing = true;
            }
        }
    }
}
