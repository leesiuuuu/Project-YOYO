using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Player ID"), SerializeField]
    public int PlayerID { get; set; }

    [Header("Player Status")]
    [SerializeField] protected float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    [SerializeField] protected float _jumpForce;
    public float JumpForce => _jumpForce;

    public PlayerInputController PlayerInput { get; private set; }

    [Header("Component")]
    private Rigidbody2D _rigid;
    public Rigidbody2D Rigid => _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        PlayerInput = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveDir = PlayerInput.MoveInput.x;
        transform.Translate(new Vector3(moveDir * _moveSpeed * Time.deltaTime, 0, 0));
    }
}
