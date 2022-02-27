using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //get killiable
        Destroy(gameObject);
    }
}
