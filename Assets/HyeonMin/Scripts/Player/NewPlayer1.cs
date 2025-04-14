using UnityEngine;

public class NewPlayer1 : MonoBehaviour
{
    Rigidbody2D rigid;
    PushGlove glove;
    NewPlayer1Grab grab;
    GameObject Grab;

    public float moveSpeed = 4f;
    public float x;
    public bool jumpAble = true;
    public bool Push;
    public bool flip;
    public float pushCharge = 0f;
    public float maxPushCharge = 35f;
    public float chargeTime = 1f;
    private bool isCharging = false;

    private float RPressTime = 0f;
    [SerializeField] private float RotSpeed = 1f;
    public float maxAngle = 20f;

    [field: Header("IsGamePad"), SerializeField]
    public bool IsGamePad { get; set; } = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        glove = GetComponentInChildren<PushGlove>();
        grab = GetComponentInChildren<NewPlayer1Grab>();
        Grab = GameObject.Find("Grab1");
    }

    private void Update()
    {
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
            }
        }
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");

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
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(moveSpeed * -1f * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
        }
        else
        {

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

        }
    }
}
