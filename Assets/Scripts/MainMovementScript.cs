using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMovementScript : MonoBehaviour
{
    public Rigidbody myBody;
 
    public float min_X, max_X;
    public float min_y, max_y;
    public float _upForce, _downForce, _leftForce, _rightForce;
    private bool moveLeft, moveRight,moveUp,moveDown;
    public float rotationSpeed;
    public bool _playerBoost;
    public Transform _startPoint;
    public bool _gameStarted;
    public AudioSource _boostSound;
    public AudioSource _ambientSound;
    

  

    void Start()
    {
        Time.timeScale = 1f;
        myBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (_gameStarted) {
            
            Move();
            MovementBounds();
            ChangeRotation();

        }

    }
    

    void Move()
    {
        
        if (!_playerBoost)
        {
            myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, 100f);
           
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            moveUp = true;
            myBody.velocity = new Vector3(myBody.velocity.x, _upForce, myBody.velocity.z);
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            moveDown = true;
            myBody.velocity = new Vector3(myBody.velocity.x, -_downForce, myBody.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            myBody.velocity = new Vector3(0, 0, myBody.velocity.z);
            moveUp = false;

        }
        if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            myBody.velocity = new Vector3(0, 0, myBody.velocity.z);
            moveDown = false;

        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            myBody.velocity = new Vector3(-_leftForce, myBody.velocity.y, myBody.velocity.z);
            moveLeft = true;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            myBody.velocity = new Vector3(_rightForce, myBody.velocity.y, myBody.velocity.z);
            moveRight = true;
        }
       
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            myBody.velocity = new Vector3(0, 0, myBody.velocity.z);
            moveLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            myBody.velocity = new Vector3(0, 0, myBody.velocity.z);
            moveRight = false;
        }
    }
     void MovementBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x < min_X)
        {
            temp.x = min_X;
            moveLeft = false;
        }
        if (temp.x > max_X)
        {
            temp.x = max_X;
            moveRight = false;
        }
        
        if (temp.y < min_y)
        {
            temp.y = min_y;
            moveDown = false;
        }
        if (temp.y > max_y)
        {
           temp.y = max_y;
            moveUp = false;
        }
        transform.position = temp;

    }
    void ChangeRotation()
    {
        if (moveRight)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, -15f), Time.deltaTime * rotationSpeed);
        }
        else if (moveLeft)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 15f), Time.deltaTime * rotationSpeed);
        }else if (moveDown)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(15f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }else if (moveUp)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-15f, 0, 0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }


    }
    public void PlayerBoost()
    {
        
        _playerBoost = true;
        _boostSound.Play();
        myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, 200f);
        StartCoroutine(StopPlayerBoost());
    }
    public IEnumerator StopPlayerBoost()
    {
        yield return new WaitForSeconds(4f);
        myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, 100f);
        _playerBoost = false;

    }
    public void StartGame()
    {
        myBody.position = new Vector3(_startPoint.position.x, _startPoint.position.y, _startPoint.position.z);
        _gameStarted = true;
        _ambientSound.Play();

    }
public void StopAmbientSound()
    {
        _ambientSound.Stop();
    }

}
