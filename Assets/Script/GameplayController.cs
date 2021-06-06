using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    public GameOverOverlay gameOverOverlay;

    public BoxSpawner box_spawner;

    public Button restartButton;

    public Button exitButton;

    [HideInInspector]
    public ScoreScript scoreScript;

    [HideInInspector]
    public BoxScript currentBox;

    public GameObject lastBox;

    public CameraScript cameraScript;

    private int moveCount;
    void Awake() {
        if(instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
		restartButton.onClick.AddListener(RestartGame);
        // Button exit = exitButton.GetComponent<Button>();
        exitButton.onClick.AddListener(ExitGame);
        box_spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput(){
        if(Input.GetMouseButtonDown(0)){
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox(){
        Invoke("NewBox",1f);
    }

    public void NewBox(){
        box_spawner.SpawnBox();
    }

    public void MoveCamera(){
        moveCount++;

        if(moveCount == 3){
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }

    public void RestartGame(){
        ScoreScript.value = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    public void ExitGame(){
        ScoreScript.value = 0;
        Debug.Log("ea");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu Scene");
    }

    public void GameOver(){
        gameOverOverlay.valueEnd = ScoreScript.value;
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if(gameOverOverlay.valueEnd > highscore){
            gameOverOverlay.isHighScore = true;
            PlayerPrefs.SetInt("highscore",gameOverOverlay.valueEnd);
        } else {
            gameOverOverlay.isHighScore = false;
            gameOverOverlay.valueHighScore = highscore;
        }
        gameOverOverlay.ShowScreen();
    }

}
