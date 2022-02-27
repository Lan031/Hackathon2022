using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_manager : MonoBehaviour
{
    [SerializeField] GameObject bulletInstance;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bulletInstance, transform.position, transform.rotation);
        Instantiate(bulletInstance, transform.position + new Vector3(.1f,.1f), transform.rotation);
        Instantiate(bulletInstance, transform.position + new Vector3(.1f, -.1f), transform.rotation);
        Destroy(gameObject);
    }

}
