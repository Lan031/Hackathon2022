using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class Camera_script : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public Transform[] curPlayer;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        //curPlayer = FindCurPlayer();
        //cam.Follow = curPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPlayer();
    }

    //Transform[] FindCurPlayer()
    //{
        //return GameObject.FindGameObjectsWithTag("Player").transform;
   // }
    /*void CheckPlayer()
    {
        //Transform[] checkPlayer = FindCurPlayer();
        if (checkPlayer == null)
        {
            //cam.Follow = checkPlayer;
        }
    }*/
}
