using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _player;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;

    private int _currentHealth;
    void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if (Input.GetButtonDown("AttackE"))
            _player.ApplyDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            Destroy(gameObject);
            _player.AddMoney(_reward);
        }
    }
}
