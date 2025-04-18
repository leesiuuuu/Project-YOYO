using UnityEngine;

public class NewPlayer1 : MonoBehaviour
{
    Rigidbody2D rigid;
    NewPushGlove glove;
    NewPlayer1Grab grab;
    GameObject Grab;

    Animator anim;

    public float moveSpeed = 4f;
    public int x;
    public bool jumpAble = true;
    public bool Push;
    public bool flip;
    public float pushCharge = 0f;
    public float maxPushCharge = 35f;
    public float chargeTime = 1f;
    private bool isCharging = false;

    public bool cantMove;

    private float RPressTime = 0f;
    [SerializeField] private float RotSpeed = 1f;
    public float maxAngle = 20f;

    [field: Header("IsGamePad"), SerializeField]
    public bool IsGamePad { get; set; } = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = transform.parent.GetComponent<Animator>();
        glove = GetComponentInChildren<NewPushGlove>();
        grab = GetComponentInChildren<NewPlayer1Grab>();
        Grab = GameObject.Find("Grab1");
    }

    private void Update()
    {
 
        if (cantMove)
            return;
        if (!grab.grabing)
        {
            GrabRot();
        }

        glove.player1PushPower = pushCharge;

        if (!IsGamePad)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isCharging = true;
                pushCharge = 0f;
            }
            if (Input.GetKey(KeyCode.E) && isCharging)
            {
                pushCharge += (maxPushCharge / chargeTime) * Time.deltaTime;
                if (pushCharge > maxPushCharge)
                {
                    pushCharge = maxPushCharge;
                }
            }
            if (Input.GetKeyUp(KeyCode.E) && isCharging)
            {
                isCharging = false;
                Push = true;
            }

            if (Input.GetKeyDown(KeyCode.W) && jumpAble)
            {
                rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                jumpAble = false;
                anim.Play("Jump");
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump1") && jumpAble)
            {
                rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                jumpAble = false;
                anim.Play("Jump");
            }

            if (Input.GetButtonDown("Push1"))
            {
                Debug.Log("���� ����");

                isCharging = true;
                pushCharge = 0;
            }
            if (Input.GetButton("Push1") && isCharging)
            {
                Debug.Log("��¡ ��");

                pushCharge += (maxPushCharge / chargeTime) * Time.deltaTime;
                if (pushCharge > maxPushCharge)
                {
                    pushCharge = maxPushCharge;
                }
            }
            if (Input.GetButtonUp("Push1") && isCharging)
            {
                Debug.Log("��¡ ��");

                isCharging = false;
                Push = true;
            }
        }
    }
    

    private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;
        if (cantMove)
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
            x = (int)Input.GetAxisRaw("Horizontal1");

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(moveSpeed * -1f * Time.deltaTime, 0, 0);
                if (jumpAble)
                    anim.Play("Move");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                if (jumpAble)
                    anim.Play("Move");
            }
            else
            {
                if (jumpAble)
                    anim.Play("Idle");
            }
        }
        else
        {
            x = (int)Input.GetAxisRaw("JoyStick1");
            transform.Translate(x * moveSpeed * Time.deltaTime, 0, 0);
            if (jumpAble && x != 0)
                anim.Play("Move");
            else if (x == 0)
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                RPressTime = Time.time;
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.R))
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

            if (Input.GetKeyUp(KeyCode.R))
            {
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.GetButtonDown("Pull1"))
            {
                Debug.Log("�׷� ��¡ ����");
                RPressTime = Time.time;
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetButton("Pull1"))
            {
                Debug.Log($"{Time.time - RPressTime}");

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

            if (Input.GetButtonUp("Pull1"))
            {
                Grab.transform.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log("�׷� ��¡ ��");
            }
        }
    }

    public void Die()
    {
        anim.Play("Die");
        cantMove = true;
    }

    public void Cleared()
    {
        cantMove = true;
        anim.Play("Cleared");
    }
}
