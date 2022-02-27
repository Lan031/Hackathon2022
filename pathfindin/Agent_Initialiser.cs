using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_Initialiser : MonoBehaviour
{
    GridPoints grid;
    //[SerializeField]pathfinding_agent agent;
    [SerializeField] Path boss;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridPoints>();
        //boss.thisTransform = this.transform;
        //agent = GetComponent<pathfinding_agent>();
        //boss = GetComponent<Alien_boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grid.Generated)
        {
            //agent.enabled = true;
            boss.enabled = true;
            this.enabled = false;
        }
    }
}
