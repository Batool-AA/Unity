using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private float health = 10f;

    public AudioSource source;
    public AudioClip k;
    public AudioClip b;
   
    public bool HealthDeplete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthDeplete)
        {
            setCount("Blue", -0.1f);
        }

        if (health <= 0)
        {
            FindObjectOfType<GameManager>().LoseLife();
            health = 10f;
        }
    }

    public int getCount(string c)
    {
        switch (c)
        {
            case "Blue":
                return (int)health;
            default:
                return 0; 
        } 
    }

    public int setCount(string c, float i)
    {
        switch (c)
        {
            case "Blue":
                source.PlayOneShot(b);
                health += i;
                if (health > 10f)
                {
                    health = 10f;
                }
                return 0;
            case "Key":
                source.PlayOneShot(k);
                FindObjectOfType<GameManager>().Win();
                return 0;
            default:
                return 0; 
        } 
    }

    public void Reset()
    {
        health = 10f;
    }
}
