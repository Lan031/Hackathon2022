using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy_Throw : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    int bounceNum = 4;
    int bounce;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounce++;
        if(bounce >= bounceNum)
        {
            Destroy(gameObject);
        }

        //get killiable
        Player_death fire = collision.gameObject.GetComponent<Player_death>();
        if (fire != null)
        {
            fire.takeDamage(damage);
        }
        else
        {
            enemy_Killiable target = collision.gameObject.GetComponent<enemy_Killiable>();
            if (target != null)
            {
                target.takeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}
