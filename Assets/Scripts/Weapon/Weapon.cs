using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    [Header("Общие параметры")]
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;
    [SerializeField] private Sprite _icon;

    [Header("Параметры выстрела")]
    [SerializeField] public float _shotTime;
    [SerializeField] protected GameObject _prefabBullet;
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected float _rightRotation;
    [SerializeField] protected float _leftRotation;
    [SerializeField] protected Transform _shootPoint;

    [HideInInspector] public Vector3 mousePos;

    public abstract IEnumerator Shoot();
}
