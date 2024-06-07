using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureNPC : MonoBehaviour
{
    private float speed;
    public GameObject dialogueBox;
    private Text textBox;
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2f, 4f);   
        dialogueBox.SetActive(false);
        textBox = dialogueBox.GetComponentInChildren<Text>();
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
            transform.position -= Vector3.forward * speed * Time.deltaTime;

            if (transform.position.z >= 59f || transform.position.z <= 25f)
            {
                speed = -speed;
                transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            textBox.text = "I shall not let you cross";
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
