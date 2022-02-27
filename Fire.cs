using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Extinguish(int dam)
    {
        health -= dam;
        if(health <= 0)
        {
            GameCounter.score++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy_Killiable target = collision.GetComponent<enemy_Killiable>();
        Player_death otherTarget = collision.GetComponent<Player_death>();
        if(target != null)
        {
            target.takeDamage(damage);
        }
        if(otherTarget != null)
        {
            otherTarget.takeDamage(damage);
        }
    }
}
