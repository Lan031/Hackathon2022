using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridPoints : MonoBehaviour
{
    public bool Generated;
    public IntVector2 size = new IntVector2(29, 17);
    public Node[,] nodes;
    [SerializeField] public Transform[] objects;
    [SerializeField] Transform alien;
    [SerializeField] FireSpawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        //this should hopefully create the grid for the pathfinding agent to walk across
        SpawnNodes();
        CreateConnections();
        assignPreliminaryCost();
        Generated = true;
        Debug.Log(Generated);
        spawn.enabled = true;
    }

    Node CreateNode(int x, int y)
    {
        Node newNode = new Node();
        newNode.x = x;
        newNode.y = y;
        //world position
        newNode.position = new Vector2(x - size.x/2 + .5f, y - size.y/2 + .5f);
        return newNode;

    }
    public IntVector2[] dirs =
    {
       new IntVector2(0,1),
       new IntVector2(1,0),
       new IntVector2(0,-1),
       new IntVector2(-1, 0),

    };
    void SpawnNodes()
    {
        //generate nodes
        nodes = new Node[size.x, size.y];

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                nodes[i, j] = CreateNode(i, j);
                //the adjectent nodes will be asigned later
            }
        }
    }
    void CreateConnections()
    {
        foreach (Node node in nodes)
        {

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    node.connectedNodes.Add(nodes[node.x + dirs[i].x, node.y + dirs[i].y]);
                    
                }
                catch
                {

                }
            }
            
        }
    }
    void assignPreliminaryCost()
    {
        foreach (Node node in nodes)
        {
            if (hitsObject(node))
            {
                //ridiculously high number so is always avoided
                node.cost = 100000;
            }
            else
            {
                //this will change depending on route but it means it is considered
                node.cost = 0;
            }
        }
    }
    bool hitsObject(Node node)
    {
        foreach (Transform obj in objects)
        {
            if(node.position == new Vector2(obj.position.x, obj.position.y))
            {
                return true;
            }
        }
        return false;
    }
}
