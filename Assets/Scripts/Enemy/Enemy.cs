using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;
    void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if( _currentHealth < 0 ) 
            Destroy(gameObject);
    }
}
