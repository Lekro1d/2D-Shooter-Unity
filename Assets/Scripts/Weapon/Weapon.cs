using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _shootPoint;

    public void Shoot()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -rotateZ));
        else
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotateZ));

        Instantiate(_prefabBullet, _shootPoint.position, _shootPoint.rotation);
    }   
}
