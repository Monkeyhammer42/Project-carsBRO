using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerHealthScrpit>().ApplyDamage(-50);
            this.gameObject.SetActive(false);
        }

    }
}
