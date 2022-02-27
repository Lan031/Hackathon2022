using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    GridPoints Points;

    [SerializeField] Rigidbody2D rb;

    Transform Goal;


    Queue<Vector2> pathQ;

    private Node curNode;

    Node PlayerPos;

    //the edge of the search
    protected Queue<Node> frontier = new Queue<Node>();
    //this contains where a cell added to the frontier came from
    //the identifier is the node in question and the other one is the node it came from
    protected Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();

    float moveWait;
    bool madePath;
    bool foundPath;

    // Start is called before the first frame update
    void Start()
    {
        //get scripts and components
        Points = GameObject.Find("Gamemanager").GetComponent<GridPoints>();
        Goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        PlayerPos = NearestNodeToPlayer();

        curNode = NearestNodeToPos();
        frontier.Enqueue(curNode);
        transform.position = frontier.Peek().position;
        cameFrom.Add(curNode, curNode);
    }

    // Update is called once per frame
    void Update()
    {
        Node CurPlayerPos = NearestNodeToPlayer();
        Node SelfNode = NearestNodeToPos();
        //this resets the grid for pathfinding
        if (CurPlayerPos != PlayerPos)
        {
            foundPath = false;
            pathQ.Clear();
            PlayerPos = CurPlayerPos;
            curNode = SelfNode;
            pathQ.Clear();
            frontier.Clear();
            cameFrom.Clear();
            frontier.Enqueue(curNode);
            transform.position = frontier.Peek().position;
            cameFrom.Add(curNode, curNode);
            madePath = false;
        }




        if (!madePath)
        {
            createGridThing();
            madePath = true;
            Debug.Log("PathMade");
        }
        if (!foundPath)
        {
            
            FindPath();

            foundPath = true;
        }
        if(madePath && foundPath)
        {
            //hopefully allows the thing to move
            if(pathQ.Count != 0)
            {
                if(moveWait > 0.15f)
                {
                    moveWait = 0;
                    rb.MovePosition(pathQ.Peek()/* * 0.5f * Time.deltaTime*/);
                    pathQ.Dequeue();
                }
                else
                {
                    moveWait += Time.deltaTime;
                }
                /*do
                {

                } while (transform.position != new Vector3(pathQ.Peek().x, pathQ.Peek().y));*/
            }
        }

    }
        
        //Debug.Log(transform.position);
        
    

    Node NearestNodeToPos()
    {
        Vector2 pos = new Vector2(Mathf.Round(transform.position.x) + 0.5f, Mathf.Round(transform.position.y) + 0.5f);
        foreach (Node node in Points.nodes)
        {
            if(node.position == pos)
            {
                Debug.Log(pos);
                return node;
            }
        }
        return null;
    }
    Node NearestNodeToPlayer()
    {
        Vector2 pos = new Vector2(Mathf.Round(Goal.position.x) + 0.5f, Mathf.Round(Goal.position.y) + 0.5f);
        foreach (Node node in Points.nodes)
        {
            if (node.position == pos)
            {
                Debug.Log(pos);
                return node;
            }
        }
        return null;
    }

    private void createGridThing()
    {
        //this should search the grid to find things
        while (frontier.Count > 0)
        {
            /*if (frontier.Peek().position == new Vector2(Goal.position.x, Goal.position.y))
            {
                //this stops the search searching after its found the goal
                break;
            }*/
            Node curNode = frontier.Dequeue();
            GetNeighbours(curNode);
        }
    }
    private void FindPath(/*Transform Goal, Transform self*/)
    {
        List<Vector2> path = new List<Vector2>();
        //this is for finding the path
        //move between them with rb.moveposition
         Node current = NearestNodeToPlayer();
        Node Start = NearestNodeToPos();
        while (cameFrom[current] != current)
        {
            path.Add(current.position);
            Debug.Log(cameFrom[current].position);
            current = cameFrom[current];
        }
        //foundPath = true;
        path.Reverse();
        pathQ = new Queue<Vector2>(path);
        path.Clear();
    }

    private void GetNeighbours(Node curNode)
    {
        //need to access the overall grid
        //this is the list of neaibours
        foreach (Node node in curNode.connectedNodes)
        {
            //if it isn't allready from anywhere
            if (!cameFrom.ContainsKey(node))
            {
                frontier.Enqueue(node);
                cameFrom.Add(node, curNode);
            }
        }
    }
}
