using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_boss : MonoBehaviour
{

    /// <summary>
    /// jump towards then circles the player
    /// if the health gets too low it will run away
    /// </summary>
    /// 
    [SerializeField] pathfinding_agent agent;
    [SerializeField] Rigidbody2D rb;
    Transform Player;
    [SerializeField] float speed;
    [SerializeField] float minCircleDist;
    [SerializeField] float rotSpeed;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPlayer())
        {

            /*//GetPos();
            //pos = FindPos();
            float dist = Vector2.Distance(transform.position, pos);
            
            //if there is a greater distance move towards player
            if (dist > minCircleDist)
            {
                //rb.MovePosition(transform.position + movePos(dist, pos) * speed * Time.deltaTime);
                // * speed * Time.deltaTime
                rb.AddForce(movePos(dist, Player.position) * speed, ForceMode2D.Force);
            }
            else
            {
                //now close enough circle then at intervals attack
                //transform.RotateAround(Player.position, Vector3.forward, rotSpeed * Time.deltaTime);
                //attack
            }*/

            //test pathfinder
            //sets the goal
            agent.Goal = Player;
            //follows the path
            for (int i = 0; i < agent.path.Count; i++)
            {
                rb.MovePosition(agent.path[i]);
            }
            
        }
    }

    float trianglulatePlayer()
    {
        Vector2 pos = transform.position - Player.position;
        float rot = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        return rot + 180;
    }
    bool CheckPlayer()
    {
        if(Player != null)
        {
            return true;
        }
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        return false;
    }

    private Vector2 movePos(float dist, Vector3 target)
    {
        //we have an angle
        //and a distance of 1
        Vector2 pos = transform.position - target;

        Vector2 newPos = new Vector2(pos.x / dist, pos.y / dist);

        return newPos * -1;
        
    }

    void GetPos()
    {
        if (pos == Vector2.zero || transform.position == new Vector3(pos.x, pos.y, transform.position.z))
        {
            pos = FindPos();
        }
    }

    private Vector2 FindPos()
    {
        float angle = Random.Range(0, 360);

        float x = findX(angle);

        Vector2 pos = new Vector2(x, findY(x));

        return pos;
    }
    float findX(float angle)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * minCircleDist;

        return x + Player.position.x;

    }

    float findY(float x)
    {
        float y = Mathf.Pow(minCircleDist, 2) - (x - Player.position.x) + Player.position.y;

        return y;
    }

    

}
