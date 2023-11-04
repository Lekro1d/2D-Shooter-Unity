using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _startShootTime;
    [SerializeField] private CharacterController2D _controller;


    private float _shootTime;
    private int _currentHealth;
    void Start()
    {
        _currentHealth = _health;
        _shootTime = _startShootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shootTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //Vector3 gunPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                int shootDirection = (_weapon.mousePos.x < _weapon.transform.position.x) ? 1 : -1;
                _controller.Shoot(shootDirection);
                _weapon.StartCoroutine(_weapon.Shoot());
                _shootTime = _startShootTime;
            }
        }
        _shootTime -= Time.deltaTime;
    }
}
