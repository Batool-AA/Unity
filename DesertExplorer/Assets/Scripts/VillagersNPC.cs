using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagersNPC : MonoBehaviour
{
    private bool Colliding = false;
    public GameObject dialogueBox;
    private Text textBox;
    private string[] allTexts = 
    {
        "The world beyond our village is fraught with peril. Rival hunters, fearsome creatures, and treacherous caves await you. Keep your health intact and watch the time, for both are in short supply.",
        "Time is against you. Take what you need and move quickly.",
        "We're scared for you. Many have tried and failed. Please come back safe.",
        "The cave where the treasure lies is full of dangers. Keep your guard up at all times."
    };


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        textBox = dialogueBox.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) & Colliding)
        {
            dialogueBox.SetActive(true);
            textBox.text = allTexts[int.Parse(gameObject.name)];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Colliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Colliding = false;
            dialogueBox.SetActive(false);
            textBox.text = "";
        }
    }
}
