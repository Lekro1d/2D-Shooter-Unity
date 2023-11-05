using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _startShootTime;
    [SerializeField] private CharacterController2D _controller;

    public int Money { get; private set; }
    private float _shootTime;
    private int _currentHealth;

    public UnityAction<int> MoneyChanged;
    public UnityAction<int, int> HealthChanged;
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
                int shootDirection = (_weapon.mousePos.x < _weapon.transform.position.x) ? 1 : -1;
                _controller.Shoot(shootDirection);
                _weapon.StartCoroutine(_weapon.Shoot());
                _shootTime = _startShootTime;
            }
        }
        _shootTime -= Time.deltaTime;
    }
    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }
    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
}
