using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = transform.position.z;

        var playerPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - playerPos.x;
        mousePos.y = mousePos.y - playerPos.y;

        var lookAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));
    }
}
