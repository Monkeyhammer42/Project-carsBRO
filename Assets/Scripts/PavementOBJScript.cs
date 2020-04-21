using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavementOBJScript : MonoBehaviour
{
    public int _individualDmage;
    public ParticleSystem ExplosionFX;
    public Transform EXP;
    public AudioSource ExplosionSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Deactivate();
    }
    private void OnTriggerEnter(Collider target)
    {
       
        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealthScrpit>().ApplyDamage(_individualDmage);
            ExplosionSound.Play();
           ExplosionFX.Play();
            StartCoroutine(DeactivateTime());

        }
        else
        {
            ExplosionFX.Play();
            StartCoroutine(DeactivateTime());
        }
        
    }
    private void Deactivate()
    {
        Vector3 temp = transform.position;
        if (temp.z < GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z)
        {
            StartCoroutine(DeactivateTime());
        }
    }
    IEnumerator DeactivateTime()
    {
        yield return new WaitForSeconds(0.5f);
        
        Destroy(this.gameObject);
    }

}
