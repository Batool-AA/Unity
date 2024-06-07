using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public AudioSource source;
    public AudioClip water;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Inventory>().HealthDeplete = true;
            playAudio();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           FindObjectOfType<Inventory>().HealthDeplete = false;
        }
    }

    private void playAudio()
    {
        source.PlayOneShot(water);
    }
}
