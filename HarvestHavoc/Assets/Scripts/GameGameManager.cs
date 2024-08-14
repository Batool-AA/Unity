//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGameManager : MonoBehaviour
{
    private float time;
    private float health;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject gameScreen;

    public GameObject Player;

    public Text timeText;
    public Text healthText;
    public bool to_barn;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        time = 180f;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        to_barn = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        timeText.text = "Time: " + (int)time;
        healthText.text = "Health: " + (int)health;

        if (time <= 0f || health <= 0)
        {
            loseScreen.SetActive(true);
            gameScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else if (to_barn)
        {
            winScreen.SetActive(true);
            gameScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void decreaseHealth(float h)
    {
        health -= h;
    }

    public void ReStart()
    {
        health = 100f;
        time = 180f;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.transform.localPosition = new Vector3(-45, -9.9f, -81.5f);
        Player.transform.localRotation = new Quaternion(0, 0, 0, 1);
        to_barn = false;
    }  
}
