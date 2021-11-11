using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    //public AudioSource audioGlass;

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MagicBall")
        {

            Instantiate(destroyedVersion, transform.position, transform.rotation);
           // audioGlass.Play();
            Destroy(gameObject);
        }

    }
}
