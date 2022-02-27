using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    [SerializeField] FireSpawner spwn;
    [SerializeField] Text txt;

    private void Update()
    {
        txt.text = ""+(spwn.time);
    }
}
