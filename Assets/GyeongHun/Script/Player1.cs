using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rigid;

    public float moveSpeed;

    public float x;

    public bool jumpAble;
    public bool Push;

    public bool flip;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveSpeed = 4f;
        jumpAble = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpAble)
        {
            rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
            jumpAble = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && !Push)
        {
            Push = true;
        }
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal1");

        if (x > 0 && flip)
        {
            Flip();
        }
        else if (x < 0 && !flip)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(moveSpeed * -1f * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
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
