using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Anim : MonoBehaviour
{
    Animator anim;
    Player2 player2;
    Player2Grab grab;

    bool playanim;

    private void Awake()
    {
        player2 = GetComponent<Player2>();
        anim = GetComponent<Animator>();
        grab = GetComponentInChildren<Player2Grab>();
    }

    private void Update()
    {
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);

        if (player2.Push && !playanim)
        {
            anim.Play("PushGlovePlayer2");
            playanim = true;
        }

        if (stateinfo.IsName("PushGlovePlayer2") && stateinfo.normalizedTime > 0.8f)
        {
            player2.Push = false;
            playanim = false;
        }

        if (player2.Grab && !playanim)
        {
            anim.Play("Player2Grab");
            playanim = true;
        }

        if(stateinfo.IsName("Player2Grab") && stateinfo.normalizedTime > 0.9f)
        {
            player2.Grab = false;
            playanim = false;
            grab.setPosing = false;
            grab.targetingable = false;
        }
    }
}
