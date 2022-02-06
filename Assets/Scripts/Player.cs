using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float _jumpForce = 20;
    [SerializeField] protected float _movementSpeed = 20;

    protected Vector2 _velocity = Vector2.zero;
    protected Rigidbody2D _rb;

    protected bool _isGrounded = true;

    protected Color _color;
    private SpriteRenderer _sr;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _color = _sr.color;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _velocity;
    }

    protected void HandleInput()
    {
        _velocity = new Vector2(0, _rb.velocity.y);
        _velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed * Time.deltaTime, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _isGrounded = false;
        }
    }

    public void SwitchColor()
    {
        if (_color == Color.white)
        {
            _color = Color.black;
            _sr.color = Color.black;
        }
        else
        {
            _color = Color.white;
            _sr.color = Color.white;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;

        IInteractable interactable = collision.gameObject.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }
}
