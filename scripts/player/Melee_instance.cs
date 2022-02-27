using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_instance : MonoBehaviour
{
    [SerializeField] GameObject AttackInstance;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(AttackInstance, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
