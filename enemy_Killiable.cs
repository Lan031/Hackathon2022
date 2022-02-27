using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemy_Killiable : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] Path path;
    [SerializeField] Animator anim;
    [SerializeField] GameObject txt;
    [SerializeField] FireSpawner spwn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameCounter.EnemyHealth = health;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");

        if (health <= 0)
        {
            GameCounter.score += 50;
            GameCounter.EnemyHealth = 0;
            txt.SetActive(true);
            GameCounter.score += (int)((5 / spwn.time) * 100);
            //flash text with alien killed
            Destroy(gameObject);

            //win
        }
        //take damage
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            //this just resets the ai if it leaves the arena
            transform.position = Vector3.down;
            path.enabled = false;
            path.enabled = true;

        }
    }
}
