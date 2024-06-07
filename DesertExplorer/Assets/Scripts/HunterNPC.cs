using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterNPC : MonoBehaviour
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
            if (gameObject.name == "0")
            {
                
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= 65f || transform.position.x <= 50f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }

            if (gameObject.name == "1")
            {
                
                transform.position += Vector3.forward * speed * Time.deltaTime;

                if (transform.position.z >= 150f || transform.position.z <= 130f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }
            
            if (gameObject.name == "2")
            {
                
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= 55f || transform.position.x <= 38f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }

            if (gameObject.name == "3")
            {
                
                transform.position -= Vector3.forward * speed * Time.deltaTime;
                transform.position += Vector3.right * speed * Time.deltaTime;

                if ((transform.position.x <= 47f & transform.position.z >= 130f) || (transform.position.x >= 56f & transform.position.z <= 119f))
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }

            if (gameObject.name == "4")
            {
                
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= 52f || transform.position.x <= 31f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }

            if (gameObject.name == "5")
            {
                
                transform.position += Vector3.forward * speed * Time.deltaTime;
                transform.position -= Vector3.right * speed * Time.deltaTime;

                if ((transform.position.x <= 42f & transform.position.z >= 128f) || (transform.position.x >= 52f & transform.position.z <= 118f))
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            textBox.text = "Hey, what are you doing here? Stay out of my territory!";
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
