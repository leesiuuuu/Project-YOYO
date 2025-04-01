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
    }

    private void Move()
    {
        float moveDir = PlayerInput.MoveInput.x;
        transform.Translate(new Vector3(moveDir * _moveSpeed * Time.deltaTime, 0, 0));
    }

    private void Flip()
    {
        _isFliped = !_isFliped;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}