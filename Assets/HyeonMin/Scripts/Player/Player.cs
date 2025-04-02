using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [field: Header("Player ID"), SerializeField]
    public int PlayerID { get; set; }

    [Header("Player Status")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    [SerializeField] private float _jumpForce;
    public float JumpForce => _jumpForce;
    private bool _canJump = true;
    private bool _isFliped = false;

    [field: Header("Component")]
    public Rigidbody2D Rigid { get; private set; }
    public PlayerInputController PlayerInput { get; private set; }

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        PlayerInput = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        if (hAxis > 0 && _isFliped)
            Flip();
        else if (hAxis < 0 && !_isFliped)
            Flip();

        Move();
        CheckGround();
    }

    private void Move()
    {
        float moveDir = PlayerInput.MoveInput.x;
        transform.Translate(new Vector3(moveDir * _moveSpeed * Time.deltaTime, 0, 0));
    }

    private void CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.2f, LayerMask.GetMask("Ground")))
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
    }

    public void Jump()
    {
        if (_canJump)
        {
            Rigid.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        _isFliped = !_isFliped;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.2f);
    }
}