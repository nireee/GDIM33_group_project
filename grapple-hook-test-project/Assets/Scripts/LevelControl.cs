using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public Transform Respawn_point;
    public GameObject Player;
    public HealthPoints hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("edge"))
        {
            Debug.Log("Fall!");
            hp.LoseOneHealth();
            Respawn();

        }
    }

    public void Respawn()
    {
        Player.transform.position = new Vector3(Respawn_point.position.x, Respawn_point.position.y, Respawn_point.position.z);
    }
}