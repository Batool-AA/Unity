//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horses : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    private Rigidbody rb;
    private bool stop;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseRandomDirection();
        speed = Random.Range(1f, 3f);
        stop = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    void Update()
    {
        if (!stop)
        {
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

        else
        {
            FindObjectOfType<GameGameManager>().decreaseHealth(0.1f);
        }
    }

    void ChooseRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        direction = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void OnTriggerEnter(Collider collision)
    {
        direction = -direction;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            stop = true;
            audioSource.Play();
        }

        else
        {
            direction = -direction;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player" && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            stop = false;
            audioSource.Stop();
        }
    }
}
