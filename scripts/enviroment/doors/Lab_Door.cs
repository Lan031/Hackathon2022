using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Door : MonoBehaviour
{
    /// <summary>
    /// key cards are going to have to link to which door it is so im going to have make other script thing to handle this(I cant be arsed now)
    /// </summary>
    Animator anim;
    Collider2D[] col;

    public Doors doorType;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this is very temporary
        Player_Inventory targetInv = collision.GetComponent<Player_Inventory>();
        if (CorrectCard(targetInv) && BoxManager.trgCount == 6)
        {
            anim.SetBool("canOpen", true);
            foreach (Collider2D c in col)
            {
                c.enabled = false;
            }
        }
    }
    bool CorrectCard(Player_Inventory targetInv)
    {
        foreach (KeyCard card in targetInv.cards)
        {
            if (card.Keytype == doorType)
            {
                return true;
            }
        }
        return false;
    }

}
