using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveNPC : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tresure;
    private float speed;
    private Vector3 originalPosition;
    public GameObject dialogueBox;
    private Text textBox;
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        dialogueBox.SetActive(false);
        textBox = dialogueBox.GetComponentInChildren<Text>();
        speed = Random.Range(1.5f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            FindObjectOfType<GameManager>().updateHealth(-0.1f);
        }

        else
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < 20f || Vector3.Distance(Tresure.transform.position, Player.transform.position) < 20f)
            {
                Vector3 direction = (Player.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                transform.position += direction * speed * Time.deltaTime;
            }

            else
            {
                Vector3 directionToOriginal = (originalPosition - transform.position).normalized;
                transform.position += directionToOriginal * speed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            textBox.text = "Don't you dare steal our treasure";
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
