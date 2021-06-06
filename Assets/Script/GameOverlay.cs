using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverlay : MonoBehaviour
{
    public GameObject overlay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
