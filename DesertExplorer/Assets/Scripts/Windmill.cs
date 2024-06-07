using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windmill : MonoBehaviour
{
    public GameObject dialogueBox;
    private Text textBox;
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        textBox = dialogueBox.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            FindObjectOfType<GameManager>().updateHealth(1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            textBox.text = "You've reached the historic windmill. Be careful, danger lies ahead!";
            colliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            textBox.text = "";
            colliding = false;
        }
    }
}
