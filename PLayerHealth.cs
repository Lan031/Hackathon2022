using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerHealth : MonoBehaviour
{
    [SerializeField] Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "you Health was: " + (GameCounter.Playerhealth);

    }
}
