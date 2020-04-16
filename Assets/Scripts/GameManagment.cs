using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public GameObject _boostPowerUp;
    public GameObject _timePowerUp;
    public GameObject _healthPowerUp;
    public Transform _player;
    public Transform[] _powerUpLanes;
    public float halfGroundSize;
    public bool _timeSlowed;
    public float timer =10;
    public Text Uitext;
    void Start()
    {
        halfGroundSize = 80f;
        
    }

    void Update()
    {
        if (_timeSlowed)
        {
            Timer();
        }
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
    public void SpawnBoost()
    {
        CreatePowerBoosts(Random.Range((_player.transform.position.z + halfGroundSize), (_player.transform.position.z + halfGroundSize) * 1.3f));
    }
    public void SpawnSlowTime()
    {
        CreateTimeBoost(Random.Range((_player.transform.position.z + halfGroundSize), (_player.transform.position.z + halfGroundSize) * 1.3f));
    }
    public void SpawnHealth()
    {
        CreateHealthBoost(Random.Range((_player.transform.position.z + halfGroundSize), (_player.transform.position.z + halfGroundSize) * 1.3f));
    }
    void AddPowerBoost(Vector3 position)
    {
        GameObject obstacle = Instantiate(_boostPowerUp, position, Quaternion.identity);
        
        obstacle.transform.position = position;
    }void AddHealthBoost(Vector3 position)
    {
        GameObject obstacle = Instantiate(_healthPowerUp, position, Quaternion.identity);
        
        obstacle.transform.position = position;
    }void AddTimeBoost(Vector3 position)
    {
        GameObject obstacle = Instantiate(_timePowerUp, position, Quaternion.identity);
        
        obstacle.transform.position = position;
    }
    void CreatePowerBoosts(float zPos)
    {
        AddPowerBoost(new Vector3(_powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.x, _powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.y, zPos));
    }
    void CreateTimeBoost(float zPos)
    {
        AddTimeBoost(new Vector3(_powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.x, _powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.y, zPos));
    }
    void CreateHealthBoost(float zPos)
    {
        AddHealthBoost(new Vector3(_powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.x, _powerUpLanes[Random.Range(0, _powerUpLanes.Length)].transform.position.y, zPos));

    }
    public void SlowTime()
    {
        if (!_timeSlowed)
        {

            Time.timeScale = 0.5f;
            StartCoroutine(SlowTimeNow());
        }
        
    }
    public IEnumerator SlowTimeNow()
    {
        yield return new WaitForSecondsRealtime(7);
        Time.timeScale = 1f;
        _timeSlowed = true;
        
        StartCoroutine(SlowTimeTimer());


    }
    public IEnumerator SlowTimeTimer()
    {
        yield return new WaitForSeconds(10);
        
            _timeSlowed = false;
        
    }
    public void Timer()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;

            Uitext.text = timer.ToString("0") + "s";
        }
        else { timer = 10; }
    }
    public void StartedGamePowerUps()
    {
        StartCoroutine(SpawnPowerUps());
    }
    public IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSecondsRealtime(10);
        float temp = Random.Range(0, 2);
        if (temp == 0)
        {
            SpawnHealth();
        }
        if (temp == 1)
        {
            SpawnBoost();
        }
        StartCoroutine(SpawnPowerUps());
    }
}


