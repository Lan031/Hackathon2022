using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding_agent : MonoBehaviour
{
    GridPoints grid;
    float searchRad = .5f;
    [SerializeField] Alien_boss boss;
    //public Transform Goal;
    public List<Vector2> path = new List<Vector2>();

    //the edge of the search
    protected Queue<Node> frontier = new Queue<Node>();
    //this contains where a cell added to the frontier came from
    //the identifier is the node in question and the other one is the node it came from
    protected Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();

    // Start is called before the first frame update
    void Start()
    {
        //Goal = boss.Player;
        grid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridPoints>();
        
        //asigns the start
        /*frontier.Enqueue(NearestNode(transform));
        transform.position = frontier.Peek().position;
        cameFrom.Add(NearestNode(transform), null);*/
    }
    
    // Update is called once per frame
    void Update()
    {
        //this creates the path so the ai just needs to follow the path
        //createGridThing();
        //FindPath();        
    }
    protected void createGridThing(Transform Goal)
    {
        //this should search the grid to find things
        while (frontier.Count > 0)
        {
            if (frontier.Peek().position == NearestNode(Goal.position).position)
            {
                //this stops the search searching after its found the goal
                break;
            }
            Node curNode = frontier.Dequeue();
            GetNeighbours(curNode);
        }
    }
    protected void FindPath(Transform Goal, Transform self)
    {
        //this is for finding the path
        //move between them with rb.moveposition
        Node current = NearestNode(Goal.position);
        Node Start = NearestNode(self.position);
        while (current != Start)
        {
            //this is a queue so when it comes to moving along the path this i just have to deque the whole path
            path.Add(current.position);
            current = cameFrom[current];
        }
        path.Reverse();

        
    }

    protected void GetNeighbours(Node curNode)
    {
        //need to access the overall grid
        //this is the list of neaibours
        foreach (Node node in curNode.connectedNodes)
        {
            //if it isn't allready from anywhere
            if(cameFrom[node] == null)
            {
                frontier.Enqueue(node);
                cameFrom.Add(node, curNode);
            }
        }
    }

    protected Node NearestNode(Vector2 pos)
    {
        foreach (Node node in grid.nodes)
        {
            if(Vector2.Distance(node.position, pos) <= searchRad)
            {
                //pos.position = node.position;
                return node;
            }
        }
        return null;
    }
}
