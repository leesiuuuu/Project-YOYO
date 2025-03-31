using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    Player2 player;
    Transform Target;

    public bool setPosing;

    private void Awake()
    {
        player = GetComponentInParent<Player2>();
    }

    private void Start()
    {
        setPosing = false;
    }

    private void Update()
    {
        if (setPosing)
        {
            Target.transform.position = gameObject.transform.position;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grabable"))
        {
            if (player.Grab)
            {
                Target = collision.gameObject.GetComponent<Transform>();
                setPosing = true;
            }
        }
    }
}
