using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private Player _player;

    private Weapon _currentWeapon;

    private void Start()
    {
        _currentWeapon = _player._weapons[0];
    }

    public void SelectWeapon(int choice)
    {
        if(_currentWeapon != null)
            _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _player._weapons[choice];
        _currentWeapon.gameObject.SetActive(true);
        _player.ChangeWeapon(_player._weapons[choice]);
        Debug.Log(choice);
    }
}
