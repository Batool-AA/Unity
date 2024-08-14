//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crops : MonoBehaviour
{
    public GameObject dialogueBox;
    private static bool scissor = false;
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
            if (scissor == true)
            {
                Destroy(gameObject);
            }

            else
            {
                dialogueBox.GetComponentInChildren<Text>().text = "Find the scissors under the pile of leaves";
                dialogueBox.SetActive(true);
            }
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
        }
    }

    public void scissorCollected()
    {
        scissor = true;
    }
}
