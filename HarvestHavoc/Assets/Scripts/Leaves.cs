//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaves : MonoBehaviour
{
    private static bool rake = false;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (rake == true)
            {
                Destroy(gameObject);
            }

            else
            {
                dialogueBox.GetComponentInChildren<Text>().text = "Find the rake amongst the horses";
                dialogueBox.SetActive(true);
            }
        }
    }

    public void rakeCollected()
    {
        rake = true;
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
        }
    }
}
