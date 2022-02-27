using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get killiable
        Fire fire = collision.GetComponent<Fire>();
        if(fire != null)
        {
            fire.Extinguish(damage);
            Destroy(gameObject);
        }
        else
        {
            enemy_Killiable target = collision.GetComponent<enemy_Killiable>();
            if(target != null)
            {
                target.takeDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                if (collision.GetComponent<TilemapCollider2D>())
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}
