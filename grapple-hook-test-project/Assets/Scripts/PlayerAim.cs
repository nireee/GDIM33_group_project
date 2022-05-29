using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private Transform _childBody;
    public LevelControl lc;
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = transform.position.z;

        var playerPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - playerPos.x;
        mousePos.y = mousePos.y - playerPos.y;

        if (lc.has_reversed == true)
        {
            mousePos.z = transform.position.z;
            mousePos.x = -mousePos.x - playerPos.x;
            mousePos.y = -mousePos.y - playerPos.y;
        }

        var lookAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));

        

        _childBody.transform.rotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.z * -1.0f);


    }
}
