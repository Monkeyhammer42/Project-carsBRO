using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimePowerUP : MonoBehaviour
{
    // Start is called before the first frame update
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
            Time.timeScale = 0.75f;
            StartCoroutine(SlowTimeAndDelete());


        }

    }
    
    public IEnumerator SlowTimeAndDelete()
    {
        yield return new WaitForSecondsRealtime(7);
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
    
}
