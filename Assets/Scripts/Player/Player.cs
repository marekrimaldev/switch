﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 20;
    [SerializeField] protected float _jumpForce = 20;
    [SerializeField] protected float _fallMultiplier = 2f;

    private Vector2 _velocity = Vector2.zero;
    private Rigidbody2D _rb;

    [SerializeField] private GroundCheckerBase _groudChecker;

    private Color _color;
    private SpriteRenderer _sr;
    private Animator _animator;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _color = _sr.color;

        _groudChecker.OnGroundEnter += OnPlayerGroundEnter;
        //_groudChecker.OnGroundExit += OnPlayerGroundExit;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_velocity.x * Time.fixedDeltaTime, _velocity.y);

        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity * (_fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        // Variable height jump
        //else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        //{
        //    _rb.velocity += Vector2.up * Physics2D.gravity * (_fallMultiplier - 1) * Time.fixedDeltaTime;
        //}
    }

    protected void HandleInput()
    {
        _velocity = new Vector2(0, _rb.velocity.y);
        _velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _groudChecker.IsGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _groudChecker.IsGrounded = false;
            OnPlayerGroundExit();
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

    /// <summary>
    /// There is a bug when using OnCollisionEnter when player verz quickly moves to one platform and
    /// out it dosent change color back. Using OnCollisionStay fix this bug eventhough its more costly.
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

    private void OnPlayerGroundExit()
    {
        _animator.SetBool("IsGrounded", false);
    }

    private void OnPlayerGroundEnter()
    {
        _animator.SetBool("IsGrounded", true);
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