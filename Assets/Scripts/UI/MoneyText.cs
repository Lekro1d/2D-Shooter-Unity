using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountM;   
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _amountM.text = _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _amountM.text = money.ToString();
    }
}
