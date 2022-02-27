using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public PlayerInput input;

    private CinemachineVirtualCamera cam;
    [SerializeField] GameObject[] chrcts;
    [SerializeField] Transform[] spawnPoints;

    int chooseVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Cinemachine cam").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.Follow == null)
        {
            
            if(chrcts[chooseVal] != null)
            {
                //chrcts[chooseVal].SetActive(true);
                Instantiate(chrcts[chooseVal], spawnPoints[chooseVal]);
                chooseVal = 0;
            }
            
        }
    }

    public void marine(InputAction.CallbackContext value)
    {
        //marin pos
        if (value.started)
        {
            chooseVal = 1;
        }
    }
    public void scientist(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            chooseVal = 2;
        }
    }
    public void engineer(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            chooseVal = 3;
        }
    }
}
