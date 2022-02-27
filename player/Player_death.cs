using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_death : MonoBehaviour
{
    [SerializeField] int Health;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Text txt;
    [SerializeField] Animator anim;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Health: " + (Health);
        GameCounter.Playerhealth = Health;

        /*if(rend.color == Color.red)
        {
            time = .1f;
        }
        if(time <= 0)
        {
            rend.color = Color.white;
        }
        else
        {
            time -= Time.deltaTime;
        }*/
    }

    public void takeDamage(int dam)
    {
        Health -= dam;
        anim.SetTrigger("hurt");
        if(Health <= 0)
        {
            GameCounter.Playerhealth = 0;
            SceneManager.LoadScene(1);
            Destroy(gameObject);

            //die  
        }
        //take damage
        
        
    }
}
