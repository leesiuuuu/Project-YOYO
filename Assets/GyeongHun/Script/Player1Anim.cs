using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1Anim : MonoBehaviour
{
    Animator anim;
    Player1 player1;

    bool playanim;

    private void Awake()
    {
        player1  = GetComponent<Player1>();
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);

        if (player1.Push && !playanim)
        {
            anim.Play("PushGlove");
            playanim = true;
        }

        if (stateinfo.IsName("PushGlove") && stateinfo.normalizedTime > 0.8f)
        {
            player1.Push = false;
            playanim = false;
        }

        if(player1.Grab && !playanim)
        {
            anim.Play("Player1Grab");
            playanim = true;
        }

        if(stateinfo.IsName("Player1Grab") && stateinfo.normalizedTime > 0.8f)
        {
            player1.Grab = false;
            playanim = false;
        }
    }
}
