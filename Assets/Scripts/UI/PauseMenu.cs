using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;
    LocalSceneManager customSceneManager;

    void Awake()
    {
        GameObject sceneManagerObject = GameObject.Find("SceneManager");
        if (sceneManagerObject == null)
        {
            throw new Exception("No SceneManager GameObject found on the scene.");
        }

        LocalSceneManager sceneManager = sceneManagerObject.GetComponent<LocalSceneManager>();
        if (sceneManager == null)
        {
            throw new Exception("No LocalSceneManager component found on SceneManager GameObject.");
        }
        this.customSceneManager = sceneManager;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        customSceneManager.LoadMenu();
    }

    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
