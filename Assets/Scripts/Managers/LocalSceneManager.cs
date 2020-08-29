using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartInfiniteGame()
    {
        SceneManager.LoadScene("InfiniteLevel");
    }
}
