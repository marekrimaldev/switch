using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 20;
    [SerializeField] protected float _jumpForce = 20;
    [SerializeField] protected float _fallMultiplier = 2f;
    [SerializeField] private GroundCheckerBase _groudChecker;

    private Rigidbody2D _rb;
    private Color _color;
    private SpriteRenderer _sr;
    private Animator _animator;

    private bool _shouldJump = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _color = _sr.color;

        _groudChecker.OnGroundEnter += OnPlayerGroundEnter;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)
                && _groudChecker.IsGrounded)
        {
            _shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_shouldJump)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _groudChecker.IsGrounded = false;
            _shouldJump = false;
            OnPlayerGroundExit();
        }

        Vector2 velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, _rb.velocity.y);
        _rb.velocity = new Vector2(velocity.x * Time.fixedDeltaTime, velocity.y);
        //_rb.velocity = velocity * Time.fixedDeltaTime;

        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity * (_fallMultiplier - 1) * Time.fixedDeltaTime;
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

    private void OnPlayerGroundExit()
    {
        _animator.SetBool("IsGrounded", false);
    }

    private void OnPlayerGroundEnter()
    {
        _animator.SetBool("IsGrounded", true);
    }

    /// <summary>
    /// There is a bug when using OnCollisionEnter when player verz quickly moves to one platform and
    /// out it dosent change color back. Using OnCollisionStay fix this bug eventhough its more costy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponentInParent<ICollisionInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }

    /// <summary>
    /// Read on OnCollisionEnter summary
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //IInteractable interactable = collision.gameObject.GetComponentInParent<IInteractable>();
        //if (interactable != null)
        //{
        //    interactable.Interact(this);
        //}

        //IParent parantable = collision.gameObject.GetComponentInParent<IParent>();
        //if (interactable != null)
        //{
        //    parantable.AddChild(transform);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponentInParent<ITriggerInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }
}
