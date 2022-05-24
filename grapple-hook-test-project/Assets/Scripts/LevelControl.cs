using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public Transform Respawn_point;
    public GameObject Player;
    public HealthPoints hp;

    public bool key_collected;
    public bool door_lock;
    public GameObject key;
    public GameObject key_door;
    // Start is called before the first frame update
    void Start()
    {
        key_collected = false;
        door_lock = true;
    }

    // Update is called once per frame
    void Update()
    {
        CompleteGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("edge"))
        {
            Debug.Log("Fall!");
            hp.LoseOneHealth();
            Respawn();

        }
        if (collision.gameObject.tag == "key")
        {
            key_collected = true;
            Destroy(key);
        }
        if (collision.gameObject.tag == "door" && key_collected == true && door_lock == true)
        {
            door_lock = false;
        }

    }

    public void CompleteGame()
    {
        if (door_lock == false)
        {
            Debug.Log("Finished!");
        }
    }

    public void Respawn()
    {
        Player.transform.position = new Vector3(Respawn_point.position.x, Respawn_point.position.y, Respawn_point.position.z);
    }
}