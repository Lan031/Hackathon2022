using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "you Score is: " + (GameCounter.score * 1000);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
