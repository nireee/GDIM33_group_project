using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject controlPanel;
    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("START");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void OpenControlPanel()
    {
        controlPanel.SetActive(true);
    }

    public void CloseControlPanel()
    {
        controlPanel.SetActive(false);
    }
}
