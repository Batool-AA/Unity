//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string t;
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
            dialogueBox.GetComponentInChildren<Text>().text = t;
            dialogueBox.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
        }
    }
}
