using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    Player2 player;
    Transform Target;

    public bool setPosing;
    public bool targetingable;

    private void Awake()
    {
        player = GetComponentInParent<Player2>();
    }

    private void Start()
    {
        setPosing = false;
        targetingable = false;
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
        if (collision.gameObject.CompareTag("interactive"))
        {
            if (player.Grab)
            {
                if(!targetingable)
                {
                    Target = collision.gameObject.GetComponent<Transform>();
                    targetingable = true;
                }
                setPosing = true;
            }
        }
    }
}
