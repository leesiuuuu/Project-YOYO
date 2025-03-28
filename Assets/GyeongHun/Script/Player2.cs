using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    PushGlove glove;

    public float moveSpeed = 4f;
    public float x;

    public bool jumpAble = true;
    public bool Push;  

    public bool flip;

    public float pushCharge = 0f;      
    public float maxPushCharge = 35f;  
    public float chargeTime = 1f;
    private bool isCharging = false; 

    private void Awake()
    {
        glove = GetComponentInChildren<PushGlove>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        glove.player2PushPower = pushCharge;

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpAble)
        {
            rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
            jumpAble = false;
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            isCharging = true;
            pushCharge = 0f;
        }
        if (Input.GetKey(KeyCode.Slash) && isCharging)
        {
            pushCharge += (maxPushCharge / chargeTime) * Time.deltaTime;
            if (pushCharge > maxPushCharge)
            {
                pushCharge = maxPushCharge;
            }
        }
        if (Input.GetKeyUp(KeyCode.Slash) && isCharging)
        {
            isCharging = false;
            Push = true;
        }
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal2");
        if (x > 0 && flip)
        {
            Flip();
        }
        else if (x < 0 && !flip)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveSpeed * -1f * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void Flip()
    {
        flip = !flip;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
