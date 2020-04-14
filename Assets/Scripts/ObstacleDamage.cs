using System.Collections;
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
        void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AiMove();
        MovementBounds();
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealthScrpit>().ApplyDamage(_individualDmage);
            
            this.gameObject.SetActive(false);
        }
        else
        {
            needToMove = true;
           // this.gameObject.SetActive(false);
        }
    }
    private void RandTimer()
    {
        int random = Random.Range(0, 8);
        if (random == 3||random==7||random==2)
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

    }
    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(2f);
        myBody.velocity = new Vector3(0f, 0f, myBody.velocity.z);
    }

}
