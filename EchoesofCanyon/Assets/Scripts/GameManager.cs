using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int lives = 3;
    private float time = 240f;
    private Vector3 playerLocation;
    private Quaternion playerRotation;

    public Text timeText;
    public Text livesText;
    public Text healthText;
    public GameObject Player;

    public GameObject YouLose;
    public GameObject YouWin;
    public GameObject gameScreen;
    public GameObject startScreen;

    public bool pauseTimer = false;
    public bool Playing = false;


    void Start()
    {
        playerLocation = Player.transform.position;
        playerRotation = Player.transform.rotation;
        startScreen.SetActive(true);
        YouLose.SetActive(false);
        gameScreen.SetActive(false);
        YouWin.SetActive(false);
    }
    
    void Update()
    {
        if (! pauseTimer & Playing)
        {
            time -= Time.deltaTime;
        }
        
        if (time <= 0)
        {
            GameOver();
        }

        
        if (Playing)
        {
            livesText.text = "Lives: " + lives;
            timeText.text = "Time: " + Mathf.Ceil(time).ToString();
            healthText.text = "Health: " + FindObjectOfType<Inventory>().getCount("Blue") + "0";
        }
        
    }

    public void LoseLife()
    {
        lives--;
        Player.transform.position = playerLocation;
        Player.transform.rotation = playerRotation;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        StartCoroutine(DeactivateLoseFrame());
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        YouLose.SetActive(false);
        gameScreen.SetActive(true);
        YouWin.SetActive(false);
        FindObjectOfType<Inventory>().Reset();
        lives = 3;
        time = 240f;
        Playing = true;
    }

    public void Win()
    {
        StartCoroutine(DeactivateWinFrame());
    }

    private IEnumerator DeactivateWinFrame()
    {
        yield return null; 
        startScreen.SetActive(false);
        YouWin.SetActive(true);
        gameScreen.SetActive(false);
        YouLose.SetActive(false);
        Playing = false;
        pauseTimer = true;
    }

    private IEnumerator DeactivateLoseFrame()
    {
        yield return null; 
        startScreen.SetActive(false);
        YouLose.SetActive(true);
        gameScreen.SetActive(false);
        YouWin.SetActive(false);
        Playing = false;
        pauseTimer = true;
    }
}
