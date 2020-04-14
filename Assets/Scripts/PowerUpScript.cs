using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    

        
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<MainMovementScript>().PlayerBoost();
            this.gameObject.SetActive(false);
        }

    }
}
