using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Pause();
        gameOver();
	}

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else if (paused == true)
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

    void gameOver()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Scoreboard");
        }
        //initiate score screen
    }
}
