using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer2 : MonoBehaviour
{
    Rigidbody2D rigid;
    NewPushGlove glove;

    NewPlayer2Grab grab;
    GameObject Grab;

    Animator anim;

    public float moveSpeed = 4f;
    public int x;

    public bool jumpAble = true;
    public bool Push;

    public bool flip;

    bool die;

    public float pushCharge = 0f;
    public float maxPushCharge = 35f;
    public float chargeTime = 1f;
    private bool isCharging = false;

    private float RPressTime = 0f;
    [SerializeField] private float RotSpeed = 1f;
    private float maxAngle = 20f;

    [field: Header("IsGamePad"), SerializeField]
    public bool IsGamePad { get; set; } = false;

    private void Awake()
    {
        glove = GetComponentInChildren<NewPushGlove>();
        rigid = GetComponent<Rigidbody2D>();

        anim = transform.parent.GetComponent<Animator>();
        grab = GetComponentInChildren<NewPlayer2Grab>();

        Grab = GameObject.Find("Grab2");

    }

    private void Update()
    {
        if (die)
            return;
        if (!grab.grabing)
        {
            GrabRot();
        }

        glove.player2PushPower = pushCharge;

        if (!IsGamePad)
        {
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

            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpAble)
            {
                rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                jumpAble = false;
                anim.Play("Jump");
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump2") && jumpAble)
            {
                rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                jumpAble = false;
                anim.Play("Jump");
            }

            if (Input.GetButtonDown("Push2"))
            {
                Debug.Log("Â÷Áö ½ÃÀÛ");

                isCharging = true;
                pushCharge = 0;
            }
            if (Input.GetButton("Push2") && isCharging)
            {
                Debug.Log("Â÷Â¡ Áß");

                pushCharge += (maxPushCharge / chargeTime) * Time.deltaTime;
                if (pushCharge > maxPushCharge)
                {
                    pushCharge = maxPushCharge;
                }
            }
            if (Input.GetButtonUp("Push2") && isCharging)
            {
                Debug.Log("Â÷Â¡ ³¡");

                isCharging = false;
                Push = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (die)
            return;
        if (!grab.grabing)
        {
            if (x > 0 && flip)
            {
                Flip();
            }
            else if (x < 0 && !flip)
            {
                Flip();
            }
        }

        if (!IsGamePad)
        {
            x = (int)Input.GetAxisRaw("Horizontal2");

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(moveSpeed * -1f * Time.deltaTime, 0, 0);
                if (jumpAble)
                    anim.Play("Move");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                if (jumpAble)
                    anim.Play("Move");
            }
            else
            {
                if(jumpAble)
                 anim.Play("Idle");
            }
        }
        else
        {
            x = (int)Input.GetAxisRaw("JoyStick2");
            transform.Translate(x * moveSpeed * Time.deltaTime, 0, 0);

            if (jumpAble && x != 0)
                anim.Play("Move");
            else if(x == 0)
                anim.Play("Idle");
        }
    }

    public void Flip()
    {
        flip = !flip;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void GrabRot()
    {
        if (!IsGamePad)
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                RPressTime = Time.time;
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.Period))
            {
                if (Time.time - RPressTime >= .5f)
                {
                    float elapsed = Time.time - RPressTime - .5f;
                    float angle = Mathf.Sin(elapsed * RotSpeed) * maxAngle;
                    Grab.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                else
                {
                    Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (Input.GetKeyUp(KeyCode.Period))
            {
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.GetButtonDown("Pull2"))
            {
                Debug.Log("±×·¦ Â÷Â¡ ½ÃÀÛ");
                RPressTime = Time.time;
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetButton("Pull2"))
            {
                Debug.Log("±×·¦ Â÷Â¡ Áß");

                if (Time.time - RPressTime >= .5f)
                {
                    float elapsed = Time.time - RPressTime - .5f;
                    float angle = Mathf.Sin(elapsed * RotSpeed) * maxAngle;
                    Grab.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                else
                {
                    Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (Input.GetButtonUp("Pull2"))
            {
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log("±×·¦ Â÷Â¡ ³¡");
            }
        }
     }

    public void Die()
    {
        anim.Play("Die");
        die = true;
    }
}
