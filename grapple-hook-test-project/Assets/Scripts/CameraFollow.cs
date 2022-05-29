using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float speedoffset;
    public Vector2 posoffset;


    public float LeftLimit;
    public float RightLimit;
    public float TopLimit;
    public float BottomLimit;

    public LevelControl lc;
    public bool camera_rotated;


    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.x += posoffset.x;
        endPos.y += posoffset.y;
        endPos.z = -10;

        //camera follow
        transform.position = Vector3.Lerp(startPos, endPos, speedoffset * Time.deltaTime);

        //set boundary
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
            Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
            transform.position.z
        );
        
    }

    public void RotateCamera()
    {
        if(lc.has_reversed == true && camera_rotated == false)
        {
            posoffset = new Vector2(2, -2.7f);
            transform.Rotate(0, 0, 180);
            camera_rotated = true;
        }
        if(lc.has_reversed == false && camera_rotated == true)
        {
            posoffset = new Vector2(2, 3.5f);
            transform.Rotate(0, 0, 0);
            camera_rotated = false;
        }
        //else
        //{
        //    posoffset = new Vector2(2, 3.5f);
        //    transform.Rotate(0, 0, 0);
        //}
    }
}
