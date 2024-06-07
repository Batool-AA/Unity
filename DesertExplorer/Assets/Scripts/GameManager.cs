using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float health = 100f;
    private float time = 120f;

    public Text healthText;
    public Text timeText;

    public GameObject startScreen;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject gameScreen;
    public GameObject Player;

    private Vector3 playerLocation;
    private Quaternion playerRotation;

    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        time = 120f;

        startScreen.SetActive(true);
        loseScreen.SetActive(false);
        gameScreen.SetActive(false);
        winScreen.SetActive(false);

        playerLocation = Player.transform.position;
        playerRotation = Player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            time -= Time.deltaTime;
        }
        

        if (time <= 0)
        {
            YouLose();
        }

        setText();
    }

    public void updateHealth(float h)
    {
        health += h;

        if (health <= 0f)
        {
            YouLose();
        }

        if (health > 100)
        {
            health = 100;
        }
    }

    private void YouLose()
    {
        startScreen.SetActive(false);
        loseScreen.SetActive(true);
        gameScreen.SetActive(false);
        winScreen.SetActive(false);

        Player.transform.position = playerLocation;
        Player.transform.rotation = playerRotation;

        playing = false;
        time = 120f;
        health = 100f;
    }

    public void YouWin()
    {
        startScreen.SetActive(false);
        winScreen.SetActive(true);
        gameScreen.SetActive(false);
        loseScreen.SetActive(false);

        Player.transform.position = playerLocation;
        Player.transform.rotation = playerRotation;

        playing = false;
        time = 120f;
        health = 100f;
    }

    private void setText()
    {
        timeText.text = "Time: " + Mathf.Ceil(time).ToString();
        healthText.text = "Health: " + Mathf.Ceil(health).ToString();
    }

    public void StartGame()
    {
        health = 100f;
        time = 120f;

        startScreen.SetActive(false);
        loseScreen.SetActive(false);
        gameScreen.SetActive(true);
        winScreen.SetActive(false);

        Player.transform.position = playerLocation;
        Player.transform.rotation = playerRotation;

        playing = true;
    }
}
