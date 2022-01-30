using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    private bool paused = false;
    public GameObject panel;
    public GameObject PanelOptions;
	
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (!paused) {
                Time.timeScale = 0;
                paused = true;
                panel.SetActive (true);
            } else {
                Time.timeScale = 1;
                paused = false;
                panel.SetActive (false);
                OptionsExit();
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        paused = false;
        panel.SetActive (false);
        OptionsExit();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Options()
    {
        PanelOptions.SetActive(true);
    }
    public void OptionsExit()
    {
        PanelOptions.SetActive(false);
    }
}