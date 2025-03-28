using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Anim : MonoBehaviour
{
    Animator anim;
    Player1 player1;

    private void Awake()
    {
        player1  = GetComponent<Player1>();
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);

        if (player1.Push)
        {
            anim.Play("PushGlove");
        }

        if (stateinfo.IsName("PushGlove") && stateinfo.normalizedTime > 0.8f)
        {
            player1.Push = false;
        }

        if(player1.Grab)
        {
            anim.Play("Player1Grab");
        }

        if(stateinfo.IsName("Player1Grab") && stateinfo.normalizedTime > 0.8f)
        {
            player1.Grab = false;
        }
    }
}
