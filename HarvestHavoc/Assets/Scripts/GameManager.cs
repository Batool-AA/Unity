//Nikem Parajuli 30446831

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject loseScreen, winScreen, startScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (loseScreen.activeInHierarchy || winScreen.activeInHierarchy)
       {
            
            if (Input.GetKeyDown(KeyCode.B))
            {
                loseScreen.SetActive(false);
                winScreen.SetActive(false);
                startScreen.SetActive(true);
            }
       } 
    }

    
}
