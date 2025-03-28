using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Anim : MonoBehaviour
{
    Animator anim;
    Player2 player2;

    private void Awake()
    {
        player2 = GetComponent<Player2>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);

        if (player2.Push)
        {
            anim.Play("PushGlovePlayer2");
        }

        if (stateinfo.IsName("PushGlovePlayer2") && stateinfo.normalizedTime > 0.8f)
        {
            player2.Push = false;
        }
    }
}
