using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] int damage;
    [SerializeField] float radius;
    float time = 0.07f;

    private void Start()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in cols)
        {
            enemy_Killiable target = collider.GetComponent<enemy_Killiable>();
            if(target != null)
            {
                target.takeDamage(damage);
                
            }
        }
        //get bool
        
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }


}
