using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPowerUp : MonoBehaviour
{
    public GameObject _healthText;
    public AudioSource _healthSound;


    private void Start()
    {
       
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            _healthSound.Play();
            target.gameObject.GetComponent<PlayerHealthScrpit>().ApplyDamage(-50);
            
            _healthText.gameObject.SetActive(true);
            StartCoroutine(WaitAndDelete());

        }

    }
    IEnumerator WaitAndDelete()
    {
        
        yield return new WaitForSeconds(1);
        _healthText.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
