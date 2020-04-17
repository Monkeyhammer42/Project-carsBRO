using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScrpit : MonoBehaviour

{
    public int healthValue = 100;
    public Slider health_Slider;
    public Text _healthText;
    //private bool canDamage;
    public Rigidbody[] _taxiPeices ;
    public GameObject UI_Holder;
    public GameObject UiButton;
    private Transform player;
    public GameObject TimeButton;
    
    public Text _TimerText;
    public float time;
    public bool isTimer;
    public string timer;
    public Text _deadTimer;
    public Text _deadDist;

    public Transform _player;
    public Transform _startPoint;
    public float distance;
    public float timex;
    public Text _distanceText;
    void Start()
    {


        health_Slider.value = healthValue;
        player = GetComponent<Transform>();

    }
    private void Update()
    {
        _healthText.text = "Health : " + healthValue;
        health_Slider.value = healthValue;
        if (isTimer)
        {
            Timer();
            _TimerText.text = time.ToString("0"+"s");
        }
        MeasureDistance();
    }

    public void ApplyDamage(int damageAmount)
    {
        
        
            healthValue -= damageAmount;

            if (healthValue < 0)
            {
                healthValue = 0;
            }
            if (healthValue > 100)
            {
                healthValue = 100;
            }
            health_Slider.value = healthValue;
            if (healthValue == 0)
            {
            _deadTimer.text = time.ToString("0") + "s";
            _deadDist.text=distance.ToString("0.00") + "KM";
            UI_Holder.SetActive(true);
            UiButton.SetActive(false);
            TimeButton.SetActive(false);

            Time.timeScale = 0.000001f;
          //  Instantiate(_taxiPeices[(0- _taxiPeices.Length)], player);
            }
        
    }
    public void MeasureTime()
    {
        isTimer =true;
    }
    public void Timer()
    {
        
        time += Time.timeScale/60;
       
    }
    public void MeasureDistance()
    {
        distance = (_startPoint.position.z + _player.position.z) / 1000;
        _distanceText.text = distance.ToString("0.00") + "KM";
    }
}
