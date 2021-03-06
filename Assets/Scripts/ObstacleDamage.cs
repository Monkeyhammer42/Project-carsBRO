﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public int _individualDmage;
    private Rigidbody myBody;
    public float min_X, max_X;
    public float min_y, max_y;
    public bool needToMove;
    public bool hasMoved;
    private GameObject _player;
    private bool GamePaused;
    public ParticleSystem ExplosionFX;
    public Transform EXP;
    private bool hasDamaged;
    public AudioSource ExplosionSound;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
            AiMove();
            MovementBounds();
            RandTimer();
        
    }
    private void OnTriggerEnter(Collider target)
    {
        if (!hasDamaged)
        {
            if (target.gameObject.tag == "Player")
            {
                ExplosionSound.Play();
                target.GetComponent<PlayerHealthScrpit>().ApplyDamage(_individualDmage);
                hasDamaged=true;
                
                ExplosionFX.Play();

                DeactivateTime();
            }
        }
        else
        {
            needToMove = true;

        }
    }
    private void RandTimer()
    {
        int random = Random.Range(0, 2000);
        if (random == 3)
        {
            needToMove = true;
        }
    }
    void AiMove()
    {
        if (!needToMove)
        {
            myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, Random.Range(10, 35));
        }
        if (needToMove)
        {
            int rand = Random.Range(0, 4);
            if (rand == 0)
            {
                myBody.velocity = new Vector3(Random.Range(2,4), myBody.velocity.y, myBody.velocity.z);
                StartCoroutine(WaitForMove());
                needToMove = false;

            }
            if (rand == 1)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, Random.Range(2, 4), myBody.velocity.z);
                StartCoroutine(WaitForMove());
                needToMove = false;
            }
            if (rand == 2)
            {
                myBody.velocity = new Vector3(Random.Range(-2, -4), myBody.velocity.y, myBody.velocity.z);
                StartCoroutine(WaitForMove());
                needToMove = false;
            }
            if (rand == 3)
            {
                myBody.velocity = new Vector3(myBody.velocity.x, Random.Range(-2, -4), myBody.velocity.z);
                
                needToMove = false;
                StartCoroutine(WaitForMove());
            }
            

        }

    }
    
    void MovementBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x < min_X)
        {
            temp.x = min_X;
            
        }
        if (temp.x > max_X)
        {
            temp.x = max_X;
            
        }

        if (temp.y < min_y)
        {
            temp.y = min_y;
           
        }
        if (temp.y > max_y)
        {
            temp.y = max_y;
           
        }
        transform.position = temp;
        if(temp.z< GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z)
        {
            StartCoroutine(DeactivateTime());
        }
        

    }
    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(2f);
        myBody.velocity = new Vector3(0f, 0f, myBody.velocity.z);
        needToMove = false;
    }
    IEnumerator DeactivateTime()
    {
        yield return new WaitForSeconds(1.5f);
        
        Destroy(this.gameObject);
    }
}
