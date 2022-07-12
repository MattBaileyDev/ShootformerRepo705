using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public bool isInMainLevel;
    public GameObject pauseCanvas;
    public bool isPaused;



    // Start is called before the first frame update
    void Start()
    {
        if (isInMainLevel == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInMainLevel && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            
        }

        if (isPaused == true)
        {
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (isPaused == false)
        {
            pauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit(); 
    }

}
