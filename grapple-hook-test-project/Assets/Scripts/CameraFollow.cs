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


    // Update is called once per frame
    void Update()
    {
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
}
