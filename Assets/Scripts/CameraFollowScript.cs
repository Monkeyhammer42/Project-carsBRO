using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform _mainPlayer;

    public float _cameraFollowDistBehind,_cameraFollwDistUp;


    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = new Vector3( _mainPlayer.position.x,_mainPlayer.position.y+_cameraFollwDistUp,_mainPlayer.position.z+_cameraFollowDistBehind);
       
    }
}
