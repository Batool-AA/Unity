//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private bool startDecrease = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startDecrease)
        {
            FindObjectOfType<GameGameManager>().decreaseHealth(0.1f);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            startDecrease = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            startDecrease = false;
        }
    }
}
