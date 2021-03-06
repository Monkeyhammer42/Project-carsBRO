﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    
    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    public GameObject[] pavementPrefabs;
    public Transform[] lanes;
    public Transform[] _pavements;
    public GameObject[] floatingPrefabs;
    public Transform[] _floatingLanes;

    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundSize;
    //private MainMovementScript playerController;
    public GameObject _player;
    private bool gameStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        
        halfGroundSize = 200f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   public void StartGameCo()
    {
        
            StartCoroutine("GenerateObstacles");
        

    }
    IEnumerator GenerateObstacles()
    {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay) / 1000f;
        yield return new WaitForSeconds(timer);
        CreateObstacles(Random.Range((_player.transform.position.z + halfGroundSize),(_player.transform.position.z + halfGroundSize)*5));
        CreateFloatingObstacles(Random.Range((_player.transform.position.z + halfGroundSize), (_player.transform.position.z + halfGroundSize) * 20));
        CreatePavementObstacles(Random.Range((_player.transform.position.z + halfGroundSize), (_player.transform.position.z + halfGroundSize) *20));
        StartCoroutine("GenerateObstacles");
    }
    void CreatePavementObstacles(float zPos)
    {
        int pavementLane = Random.Range(0, _pavements.Length);
        AddPavementObstacle(new Vector3(_pavements[pavementLane].transform.position.x, _pavements[pavementLane].transform.position.y, zPos), Random.Range(0, pavementPrefabs.Length));
    }
    void CreateFloatingObstacles(float zPos)
    {
        int floatingLanes = Random.Range(0, _floatingLanes.Length);
        AddFloatingObstacle(new Vector3(_floatingLanes[floatingLanes].transform.position.x, _floatingLanes[floatingLanes].transform.position.y, zPos), Random.Range(0, floatingPrefabs.Length));
    }

    void CreateObstacles(float zPos)
    {
        
        {
            int obstacleLane = Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, lanes[obstacleLane].transform.position.y, zPos), Random.Range(0, obstaclePrefabs.Length));


            
        }
    }
    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;


        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? 0 : 0, 0f);

                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? 0 : 0, 0f);

                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? 0 : 0, 0f);

                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? 0 : 0, 0f);

                break;
        }

        obstacle.transform.position = position;
    }
    void AddPavementObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(pavementPrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;


        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);

                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);

                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -90 : 90, 0f);

                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);

                break;
        }

        obstacle.transform.position = position;
    }
    void AddFloatingObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(floatingPrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;


        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);

                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);

                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);

                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);

                break;
        }

        obstacle.transform.position = position;
    }
}
