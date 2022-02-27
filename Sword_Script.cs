using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Script : MonoBehaviour
{
    Transform Player;

    [SerializeField] GameObject swordPrefab;
    [SerializeField] float shootDelay;
    [SerializeField] Transform shotPoint;
    [SerializeField] Transform AttackRot;

    float delay;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        AttackRot.rotation = Quaternion.Euler(0, 0, trianglulatePlayer());
        if(delay >= shootDelay)
        {
            Instantiate(swordPrefab, shotPoint.position, AttackRot.rotation);
            delay = 0;
        }
        else
        {
            delay += Time.deltaTime;
        }
    }

    float trianglulatePlayer()
    {
        Vector2 pos = transform.position - Player.position;
        float rot = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        return rot + 180;
    }
}
