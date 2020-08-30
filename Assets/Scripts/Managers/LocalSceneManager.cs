using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocalSceneManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider progressSlider;
    public Text progressText;

    public void StartGame()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void StartInfiniteGame()
    {
        StartCoroutine(LoadAsynchronously("InfiniteLevel"));
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().name));
    }

    internal void LoadMenu()
    {
        StartCoroutine(LoadAsynchronously("Menu"));        
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //  Unity load process goes from 0 to 0.9. The rest untill 1 is the Activation phase.
            progressSlider.value = progress;
            progressText.text = progress.ToString("0%"); //Converts 0 to 1 value to a '0%' to '100%' string
            Debug.Log(progress.ToString("0%"));
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously (String sceneName) //TODO merge with LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //  Unity load process goes from 0 to 0.9. The rest untill 1 is the Activation phase.
            progressSlider.value = progress;
            progressText.text = progress.ToString("0%"); //Converts 0 to 1 value to a '0%' to '100%' string
            Debug.Log(progress.ToString("0%"));
            yield return null;
        }
    }
}
