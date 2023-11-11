using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Gun : Weapon
{
    public override IEnumerator Shoot()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diference = mousePos - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;

        if (mousePos.x < transform.position.x)
        {
            rotateZ = (rotateZ < 0) ? Mathf.Clamp(rotateZ, -_leftRotation - 45, -_leftRotation) :
                                      Mathf.Clamp(rotateZ, _leftRotation, _leftRotation + 45);
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -rotateZ));
        }
        else
        {
            rotateZ = Mathf.Clamp(rotateZ, -_rightRotation, _rightRotation);  // Ограничиваем угол вправо
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotateZ));
        }
        Instantiate(_prefabBullet, _shootPoint.position, _shootPoint.rotation);

        var prefEffect = Instantiate(_effect, _shootPoint.position, _shootPoint.rotation);
        yield return new WaitForSeconds(0.2f);
        Destroy(prefEffect);
    }
}
