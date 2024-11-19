using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            Debug.Log($"pause {Time.timeScale}");
        }

        else
        {
            Time.timeScale = 1f;
            Debug.Log($"pause off {Time.timeScale}");
        }

    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
