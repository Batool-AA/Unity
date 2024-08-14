//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FindObjectOfType<AngryFarmers>().setFollow(true);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FindObjectOfType<AngryFarmers>().setFollow(false);
       }
    }
}
