using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private PlayerShooting _shooting;

    private Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _shooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if (!(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0))
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _movement = moveInput.normalized * moveSpeed;

            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);

            _shooting.ActualPlayerMovement = new Vector2(moveInput.x, moveInput.y);
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * Time.fixedDeltaTime);
    }
}
