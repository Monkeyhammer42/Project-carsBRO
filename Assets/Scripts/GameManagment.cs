using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Pause()
    {
        Time.timeScale = 0.0001f;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
