using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody myBody;
    public Vector3 speed;
    public float x_Speed = 50f, z_Speed = 100f;
    public float jumpPower;
    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;
    public float _maxJump;
    private bool canJump=true;
    public float _maxleft, _maxRight;
    private Vector3 roadPosition;
    void Awake()
    {
        speed = new Vector3(0f, 0f, z_Speed);
    }

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        roadPosition = GetComponent<Transform>().position;
    }
    void Update()
    {
        ControlMovementWithKeyboard();
        ChangeRotation();
       
    }

    void FixedUpdate()
    {
        
        MoveTaxi();
        
    }

    void MoveTaxi()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }
    void ControlMovementWithKeyboard()
    {
       

        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveToLeft();
            
            
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveToRight();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveToStraight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveToStraight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveToFast();
        }
        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S))
        {
            MoveToNormal();

        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveToSlow();

        }
        if (Input.GetKey(KeyCode.Space))
        {
            
            Vector3 jumpHeight = myBody.position;
            
            if(jumpHeight.y <= _maxJump)
            {
                MoveToUp();
                canJump = true;
            }else if (jumpHeight.y > _maxJump)
            {
                canJump = false;
                myBody.position = new Vector3(myBody.position.x, jumpHeight.y,myBody.position.z);
                myBody.AddForce(new Vector3(0, -jumpPower, 0));
            }
        }
        

    }
    void MoveToLeft()
    {
        if(roadPosition.x > _maxleft)
        {

            speed = new Vector3(-x_Speed / 2f, speed.y, speed.z);


        }
            else if (roadPosition.x <= _maxleft)
        {
            speed=new Vector3(0,0,speed.z);
        }
        
    }
    void MoveToRight()
    {
        speed = new Vector3(x_Speed / 2f, speed.y, speed.z);
    }
    void MoveToFast()
    {

        speed = new Vector3(speed.x, speed.y, 150f);
    }
    void MoveToNormal()
    {

        speed = new Vector3(speed.x, speed.y, 100f);
    }
    void MoveToSlow()
    {

        speed = new Vector3(speed.x, speed.y, 50f);
    }
    void MoveToUp()
    {
        myBody.AddForce(new Vector3(0,jumpPower,0));
    }
    
    void MoveToStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }
    void ChangeRotation()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, -15f), Time.deltaTime * rotationSpeed);
        }else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -0, 15f), Time.deltaTime * rotationSpeed);
        }else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }


    }
    

 















}
