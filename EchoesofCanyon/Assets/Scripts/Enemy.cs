using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;

    private float speed = -1.5f;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "enemy0")
        {
            if (Player.transform.position.x >= 420f & Player.transform.position.x <= 430f & Player.transform.position.z >= -622f & Player.transform.position.z <= -618f)
            {
                speed = 2f;
                Vector3 direction = (Player.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                transform.position += direction * speed * Time.deltaTime;
            }

            else
            {
                speed = 1.5f;
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= 440f || transform.position.x <= 390f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            } 
        }

        else if (gameObject.name == "enemy1")
        {
            if (Player.transform.position.x >= 32f & Player.transform.position.x <= 95f & Player.transform.position.z >= -672f & Player.transform.position.z <= -640f)
            {
                speed = 2f;
                Vector3 direction = (Player.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                transform.position += direction * speed * Time.deltaTime;
            }

            else
            {
                speed = 1.5f;
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= 100f || transform.position.x <= 29f)
                {
                    speed = -speed;
                    transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
                }
            } 
        }

        else if (gameObject.name == "enemy2")
        {
            speed = 1.5f;
            transform.position += Vector3.forward * speed * Time.deltaTime;

            if (transform.position.z >= -948f || transform.position.z <= -970f)
            {
                speed = -speed;
                transform.rotation *= Quaternion.Euler(0f, -180f, 0f);
            }
        }

        else if (gameObject.name == "enemy3")
        {
            
            if (Vector3.Distance(transform.position, Player.transform.position) < 20f)
            {
                speed = 1.5f;
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
            FindObjectOfType<Inventory>().HealthDeplete = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           FindObjectOfType<Inventory>().HealthDeplete = false;
        }
    }
}
