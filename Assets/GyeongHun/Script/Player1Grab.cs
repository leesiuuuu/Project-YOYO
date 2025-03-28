using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Grab : MonoBehaviour
{
    Player1 player;
    Transform player2;

    public bool setPosing;

    private void Awake()
    {
        player = GetComponentInParent<Player1>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
    }

    private void Start()
    {
        setPosing = false;
    }

    private void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, player.transform.position) < 1)
        {
            player.Grab = false;    
            setPosing = false;
        }

        if(setPosing)
        {
            player2.transform.position = gameObject.transform.position;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player2"))
        {
            if(player.Grab)
            {
                setPosing = true;
            }
        }
    }
}
