using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    //Basic template for game control

    public bool firstLevel;

    private int timesStopped;  //just a test integer to demo adding from GUI

    public GameObject startScreen;  //the screen to hide and show

    void Start()
    {
        //init variable
        timesStopped = 0;

        //force a resolution
        Screen.SetResolution(1366, 768, true);
        
        //pause the game if it is the first time we open game
        if(firstLevel)
            Time.timeScale = 0;
        
        //from now new scenes will start active
        firstLevel = false;


    }

    // Update is called once per frame
    void Update()
    {
        //pause when esc is pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        //show pause screen
        startScreen.SetActive(true);
        //increment our test value
        timesStopped++;
        //pause the game
        Time.timeScale = 0;

    }
    public void Resume()
    {
        //hide screen
        startScreen.SetActive(false);
        //resume time
        Time.timeScale = 1;

    }
    public void addToStopped(int add)
    {
        //just a test
        timesStopped += add;
        Debug.Log("times stopped " + timesStopped);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Scene3", LoadSceneMode.Additive);
    }

}
