using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private float _runSpeed;

    private Animator _animator;
    private float _horizontal;
    private bool _jump = false;
    private bool _crouch = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal") * _runSpeed;
        _animator.SetFloat("HorizontalMove", Mathf.Abs(_horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            _animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            _crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            _crouch = false;
        }
    }

    public void OnLanding()
    {
        _animator.SetBool("IsJumping", false);
    }

    public void OnCruching(bool crouch)
    {
        _animator.SetBool("IsCrouch", crouch);
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontal * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }
}
