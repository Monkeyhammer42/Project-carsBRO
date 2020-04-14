using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpScript : MonoBehaviour
{
    
    public bool _playerBoost;


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "PowerUp")
        {
            target.gameObject.GetComponent<MainMovementScript>().PlayerBoost();
        }

    }
}
