using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]Animator anim;

    public void Interact()
    {
        anim.SetBool("fixed", true);
        BoxManager.fixedGenerator = true;
        BoxManager.trgCount++;
        GetComponent<Generator>().enabled = false;
    }
}
