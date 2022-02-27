using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] GameObject attackInstance;

    public GameObject ShotPoint;
    public PlayerInput input;


    bool shoot;

    [SerializeField] float StartTmbtwShots;
    float TimbtwShots;

    private void Update()
    {
        shoot = ShotPoint.transform.localPosition != Vector3.zero;
        if (TimbtwShots <= 0 && shoot)
        {
            //rotation needs to be found
            float rot = getRotation();
            Instantiate(attackInstance, ShotPoint.transform.position, Quaternion.Euler(0,0,rot));
            TimbtwShots = StartTmbtwShots;
        }
        else
        {
            TimbtwShots -= Time.deltaTime;
        }
    }
    float getRotation()
    {
        Vector2 pos = transform.position - ShotPoint.transform.position;
        float rot = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;


        return rot + 180;
    }
    

}
