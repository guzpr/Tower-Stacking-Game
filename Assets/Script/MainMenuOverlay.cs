using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOverlay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject overlay;
    public Button startGame;
    void Start()
    {
        Button btn = startGame.GetComponent<Button>();
        Debug.Log(btn);
		btn.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScreen()
    {
        overlay.SetActive(true);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            "SampleScene"
        );
    }

    public void HideScreen()
    {
        overlay.SetActive(false);
    }
}
