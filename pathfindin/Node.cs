using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 position;
    public int x,y;

    public int cost;

    //nodes in the immediate vecinity
    public List<Node> connectedNodes = new List<Node>();
}
