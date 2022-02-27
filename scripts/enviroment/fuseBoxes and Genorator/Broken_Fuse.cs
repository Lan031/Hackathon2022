using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_Fuse : MonoBehaviour
{
    [SerializeField] Animator anim;
    bool isFixed;

    public void Interact(string name)
    {
        if (!isFixed && name == "Engineer(Clone)")
        {
            anim.SetBool("fixed", true);
            isFixed = true;
        }
        else
        {
            anim.SetBool("switched", true);
            BoxManager.trgCount++;
            GetComponent<Broken_Fuse>().enabled = false;
        }

    }
}
