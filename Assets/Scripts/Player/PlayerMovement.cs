using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingPower;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isFacingRight = true;
    private float _horizontal;
    private Animator _animator;
    private Collider2D _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("HorizontalMove", Mathf.Abs(_horizontal));

        Flip();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        Vector2 size = _collider.bounds.size;
        return Physics2D.OverlapBox(_groundCheck.position, size, 0f, _groundLayer);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f) 
        { 
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
