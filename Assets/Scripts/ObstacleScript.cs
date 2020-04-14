using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    
    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    public Transform[] lanes;
    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundSize;
    private MainMovementScript playerController;
    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateObstacles");
        halfGroundSize = 420f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator GenerateObstacles()
    {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay) / 300f;
        yield return new WaitForSeconds(timer);
        CreateObstacles(_player.transform.position.z + halfGroundSize);
        StartCoroutine("GenerateObstacles");
    }
    void CreateObstacles(float zPos)
    {
        int r = Random.Range(0, 10);
        if (0 <= r && r < 7)
        {
            int obstacleLane = Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, lanes[obstacleLane].transform.position.y, zPos), Random.Range(0, obstaclePrefabs.Length));


            int zombieLane = 0;
            if (obstacleLane == 0)
            {
                zombieLane = Random.Range(0, 3) == 1 ? 2 : 1 ;
            }
            else if (obstacleLane == 1)
            {
                zombieLane = Random.Range(0, 3) == 1 ? 0 : 2;
            }
            else if (obstacleLane == 2)
            {
                zombieLane = Random.Range(0, 3) == 1 ? 0 : 1;
            }
            else if (obstacleLane == 3)
            {
                zombieLane = Random.Range(0, 3) == 1 ? 0 : 2;
            }
            //AddZombies(new Vector3(lanes[zombieLane].transform.position.x, 0.15f, zPos));
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
}
