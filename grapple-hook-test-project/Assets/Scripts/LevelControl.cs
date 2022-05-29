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

    public Rigidbody2D rb;
    public bool button_pressed;
    public bool has_reversed;
    public SpriteRenderer player;

    public bool button_door_lock;
    public GameObject ButtonDoor;

    public bool EnterTrap;

    //public GameObject button_pressed_image;
    //public Transform button_pos;
    // Start is called before the first frame update
    void Start()
    {
        key_collected = false;
        door_lock = true;
        rb = Player.GetComponent<Rigidbody2D>();
        has_reversed = false;
        button_pressed = false;
        button_door_lock = true;
        EnterTrap = false;
    }

    // Update is called once per frame
    void Update()
    {
        CompleteGame();
        ReverseGravity();
        OpenButtonDoor();
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

        if (collision.CompareTag("ReverseButton"))
        {
            Debug.Log("ReverseButtonPressed!");
            button_pressed = true;
            //button_pos = collision.gameObject.transform;
            Destroy(collision.gameObject);
            //Instantiate(button_pressed_image, button_pos);
        }
        if (collision.CompareTag("button"))
        {
            button_door_lock = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap" && EnterTrap == false)
        {
            hp.LoseOneHealth();
            EnterTrap = true;
        }

        //It's a temporary method cuz I'm still working on it
        if (collision.gameObject.tag == "monster")
        {
            hp.LoseOneHealth();
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
        //may have bugs when respawn while in reversing mode
        Player.transform.position = new Vector3(Respawn_point.position.x, Respawn_point.position.y, Respawn_point.position.z);
    }

    public void ReverseGravity()
    {
        if (button_pressed == true)
        {
            rb.gravityScale *= -1;
            player.flipX = !player.flipX;
            player.flipY = !player.flipY;
            button_pressed = false;
            has_reversed = !has_reversed;
        }
    }

    public void OpenButtonDoor()
    {
        if(button_door_lock == false)
        {
            Destroy(ButtonDoor);
        }
    }
}