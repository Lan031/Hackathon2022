using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien_Killed : MonoBehaviour
{
    [SerializeField] Text txt;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        txt.enabled = false;
        

    }
}
