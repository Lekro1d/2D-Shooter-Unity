using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] public List<Weapon> _weapons;
    [SerializeField] private CharacterController2D _controller;

    public int Money { get; private set; }
    private float _currentShotTime;
    private int _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;

    public UnityAction<int> MoneyChanged;
    public UnityAction<int, int> HealthChanged;

    void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _health;
        _currentShotTime = _currentWeapon._shotTime;
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            _currentShotTime = Mathf.Clamp(_currentShotTime - Time.deltaTime, 0f, _currentWeapon._shotTime);

                if (_currentShotTime == 0 && Input.GetMouseButton(0))
                {
                    int shootDirection = (_currentWeapon.mousePos.x < _currentWeapon.transform.position.x) ? 1 : -1;
                    _controller.Shoot(shootDirection);

                    _currentWeapon.StartCoroutine(_currentWeapon.Shoot());
                    _currentShotTime = _currentWeapon._shotTime;
                }
        }
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

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.StopCoroutine(_currentWeapon.Shoot());
        }
        _currentWeapon = newWeapon;
    }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
    }
}
