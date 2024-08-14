
//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryFarmers : MonoBehaviour
{
    private static bool startFollow = false;
    public GameObject player; 
    private float followDistance = 2.0f; 
    private float moveSpeed = 2.0f; 
    private bool colliding = false;
    public GameObject dialogueBox;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startFollow & !colliding)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            direction = (player.transform.position - transform.position).normalized;
            direction.y = 0;
            float originaly = transform.position.y;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, originaly, transform.position.z);
            transform.rotation = Quaternion.LookRotation(direction);


            if (distance > followDistance)
            {
                moveSpeed = 3.0f;
            }

            else
            {
                moveSpeed = 2.0f;
            }
        }

        if (colliding)
        {
            FindObjectOfType<GameGameManager>().decreaseHealth(0.1f);
        }

        
    }

    public void setFollow(bool a)
    {
        startFollow = a;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            colliding = true;
            dialogueBox.GetComponentInChildren<Text>().text = "How dare you touch my crops!";
            dialogueBox.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            colliding = false;
            dialogueBox.SetActive(false);
        }
    }
}
