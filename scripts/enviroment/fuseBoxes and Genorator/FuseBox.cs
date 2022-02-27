using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    Collider2D col;
    Animator anim;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    public void Interact()
    {
        BoxManager.trgCount++;
        anim.SetBool("turnedOn", true);
        col.enabled = false;
    }
}
