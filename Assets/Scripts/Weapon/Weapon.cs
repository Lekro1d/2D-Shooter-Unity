using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    [Header("����� ���������")]
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;
    [SerializeField] private Sprite _icon;

    [Header("��������� ��������")]
    [SerializeField] public float _shotTime;
    [SerializeField] protected GameObject _prefabBullet;
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected float _rightRotation;
    [SerializeField] protected float _leftRotation;
    [SerializeField] protected Transform _shootPoint;

    [HideInInspector] public Vector3 mousePos;

    public string Label => _label;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;
    public Sprite Icon => _icon;

    public abstract IEnumerator Shoot();

    public void Buy()
    {
        _isBuyed = true;
    }
}
