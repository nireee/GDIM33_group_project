using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public float movingSpeed;
    private Rigidbody2D rb;
    public bool isPatrol;
    public Transform GroundCheckPos;
    public bool isTurn;
    public LayerMask ground;

    public HealthPoints hp;
    public bool TouchPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPatrol = true;
        hp = FindObjectOfType<HealthPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            EnemyPatrol();
        }
    }

    private void FixedUpdate()
    {
        if (isPatrol)
        {
            isTurn = !Physics2D.OverlapCircle(GroundCheckPos.position, 0.1f, ground);
        }
    }

    public void EnemyPatrol()
    {
        if (isTurn || TouchPlayer == true)
        {
            EnemyFlip();
            TouchPlayer = false;
        }
        rb.velocity = new Vector2(movingSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }

    public void EnemyFlip()
    {
        isPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        movingSpeed = movingSpeed * -1;
        isPatrol = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TouchPlayer = true;
            hp.LoseOneHealth();
        }
    }
}
