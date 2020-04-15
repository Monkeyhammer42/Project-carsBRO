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

    void Start()
    {


        health_Slider.value = healthValue;
        player = GetComponent<Transform>();

    }
    private void Update()
    {
        _healthText.text = "Health : " + healthValue;
        health_Slider.value = healthValue;
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
                UI_Holder.SetActive(true);
            UiButton.SetActive(false);
            Time.timeScale = 0.000001f;
          //  Instantiate(_taxiPeices[(0- _taxiPeices.Length)], player);
            }
        
    }
}
