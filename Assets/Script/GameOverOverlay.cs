using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverOverlay : MonoBehaviour
{

    public GameObject overlay;
    public Text scoreEnd;
    public Text highScore;

    public bool isHighScore = false;
    public int valueEnd = 0;
    public int valueHighScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        overlay.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        scoreEnd.text = "Your score: " + valueEnd;
        highScore.text = "Current High Score: " + valueHighScore;
        
    }

    public void ShowScreen()
    {
        overlay.SetActive(true);
    }

    public void HideScreen()
    {
        overlay.SetActive(false);
    }
    

}
