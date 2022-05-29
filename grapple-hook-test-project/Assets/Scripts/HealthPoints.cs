using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPoints : MonoBehaviour
{
    public GameObject[] HP;
    public bool[] health_status;

    public GameObject go_text;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < health_status.Length; i++)
        {
            health_status[i] = true;
        }

        go_text.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HP"))
        {
            Debug.Log("Collide with Health");
            Destroy(collision.gameObject);
            AddOneHealth();
        }
    }

    public void LoseOneHealth()
    {
        for (int i = 2; i > -1; i--)
        {
            if(health_status[i] != false)
            {
                health_status[i] = false;
                HP[i].SetActive(false);
                break;
            }
        }
    }

    public void AddOneHealth()
    {
        for (int i = 0; i < health_status.Length; i++)
        {
            if(health_status[i] == false)
            {
                health_status[i] = true;
                HP[i].SetActive(true);
                break;
            }
        }
    }

    public void CheckGameOver()
    {
        if(health_status[0] == false)
        {
            Debug.Log("GameOver!");
            Time.timeScale = 0;
            go_text.SetActive(true);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
