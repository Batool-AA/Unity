//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
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
        if (c.gameObject.tag == "Player" & gameObject.name == "Rake")
        {
            FindObjectOfType<Leaves>().rakeCollected();
            dialogueBox.GetComponentInChildren<Text>().text = "Use me to rake the leaves and find the scissors";
            dialogueBox.SetActive(true);
        }

        else if (c.gameObject.tag == "Player" & gameObject.name == "Scissor")
        {
            FindObjectOfType<Crops>().scissorCollected();
            dialogueBox.GetComponentInChildren<Text>().text = "Cut through the crops to get to the barn";
            dialogueBox.SetActive(true);
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
            Destroy(gameObject);
        }
    }
}
