using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singularity : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Interact()
    {
        anim.SetBool("fixed", true);
        Debug.Log("you have fixed the lab");
    }
}
