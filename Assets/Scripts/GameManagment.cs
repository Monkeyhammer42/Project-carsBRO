using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public Transform _player;
    public Transform _startPoint;
    public float distance;
    public float time;
    public Text _distanceText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeasureDistance();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0.0001f;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
    }
    public void MeasureDistance()
    {
        distance= _startPoint.position.z + _player.position.z;
        _distanceText.text = distance.ToString("0")+ "M";
    }
    
}
