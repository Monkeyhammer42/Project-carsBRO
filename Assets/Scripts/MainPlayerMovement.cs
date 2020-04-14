using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    
    private float speed = 5.0f;
    private Rigidbody myBody;
    private Transform turnRotation;
    private float smoothturn = 3f;
    private Transform _currentPosition;




    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        turnRotation = GetComponent<Transform>();

        
    }

    


    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            myBody.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myBody.AddForce(-transform.forward * speed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            myBody.transform.position = new Vector3(myBody.transform.position.x  -5f, myBody.transform.position.y, myBody.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            myBody.transform.position = new Vector3(myBody.transform.position.x+5f, myBody.transform.position.y, myBody.transform.position.z);
           
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    myBody.AddForce(transform.up * speed);
        //    turnRotation.Rotate(-1, 0, 0);

        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{

        //    myBody.rotation = Quaternion.Lerp(_currentPosition.rotation,Quaternion.identity,Time.deltaTime*smoothturn);
            
        //}
    }
}
