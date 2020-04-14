using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScrpit : MonoBehaviour

{
    public int healthValue = 100;
    public Slider health_Slider;
    public Text _healthText;

    public GameObject UI_Holder;

    void Start()
    {


        health_Slider.value = healthValue;


    }
    private void Update()
    {
        _healthText.text = "Health : " + healthValue;
    }

    public void ApplyDamage(int damageAmount)
    {
        healthValue -= damageAmount;
        
        if (healthValue < 0)
        {
            healthValue = 0;
        }
        health_Slider.value = healthValue;
        if (healthValue == 0)
        {
            UI_Holder.SetActive(true);

        }

    }
}
