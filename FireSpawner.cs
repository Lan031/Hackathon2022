using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireSpawner : MonoBehaviour
{
    [SerializeField]GameObject FirePref;
    Transform Player;
    GridPoints points;
    Vector2 size;
    public List<Vector2> poses = new List<Vector2>();
    [SerializeField] private float fireChance;

    //overall time in seconds
    [SerializeField] float maxTime;
    public float time;
    float FireSpawnPerSec;
    float fireTime;
    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<GridPoints>();
        size = new Vector2(points.size.x, points.size.y);
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CreateVect2();
    }

    // Update is called once per frame
    void Update()
    {
        //this will acctually be determind by time
        //have like a time thing
        /*if (Random.Range(0, fireChance) <= 1)
        {
            SpawnFire();
        }*/

        switch (time)
        {
            case 0:
                FireSpawnPerSec = 3;
                break;
            case 2.5f:
                FireSpawnPerSec = 5;
                break;
            case 5:
                FireSpawnPerSec = 8;
                break;
            case 10f:
                fireChance = 16;
                break;
        }

        //spawns per second
        if (fireTime >= .5f)
        {
            for (int i = 0; i < FireSpawnPerSec; i++)
            {
                if (poses.Count != 0)
                {
                    SpawnFire();

                }
                else
                {
                    CreateVect2();
                }
            }
            fireTime = 0;
        }
        else
        {
            fireTime += Time.deltaTime;
        }

        if (time < maxTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            //end game

            SceneManager.LoadScene(1);
            //SpawnFire();
        }
    }

        void SpawnFire()
        {
            int pos;
            Vector2 spawnPos;
            do
            {
                pos = Random.Range(0, poses.Count);
                spawnPos = poses[pos];
            } while (spawnPos == new Vector2(Player.position.x, Player.position.y));

            Instantiate(FirePref, spawnPos, transform.rotation);
            poses.Remove(spawnPos);
        }

        void CreateVect2()
        {
            foreach (Node node in points.nodes)
            {
                poses.Add(node.position);
            }
        }
    
}
