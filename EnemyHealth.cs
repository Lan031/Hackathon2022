using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "The Enemie's Health was: " + (GameCounter.EnemyHealth);

    }
}
