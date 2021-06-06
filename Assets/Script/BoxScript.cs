using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private float min_X = -3f;
    private float max_X = 3f;

    private bool canMove;
    private float move_speed = 2f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    private Vector3 startPos;

    public float delta = 6f;
    private void Awake() {
        myBody =  GetComponent<Rigidbody2D>();    
        myBody.gravityScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        move_speed = Random.Range(2f,4f);

        move_speed *= -1f;
        
        startPos = transform.position;

        GameplayController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();   
    }

    void MoveBox(){
        if(canMove){
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin (Time.time * move_speed);
            transform.position = v;
        }
    }

    public void DropBox(){
        canMove = false;
        myBody.gravityScale = 4;
    }

    void Landed(){
        if(gameOver)
        return;

        ScoreScript.value += 1;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();

    }

    void RestartGame(){
        GameplayController.instance.RestartGame();
    }

    void WaitBox(){
        // myBody.constraints = RigidbodyConstraints2D.FreezePosition;
        Invoke("Landed",0.5f);
        GameplayController.instance.lastBox = gameObject;
        ignoreCollision = true;
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(ignoreCollision) return;

            if(target.gameObject.tag == "Platform"){
                // myBody.constraints = RigidbodyConstraints2D.FreezePosition;
                if(ScoreScript.value > 0){
                    gameOver = true;
                    GameplayController.instance.GameOver();
                } else {
                    Invoke("Landed",1f);
                    ignoreCollision = true;
                    GameplayController.instance.lastBox = gameObject;
                }
            }

            if(target.gameObject.tag == "Box"){
                
                if(GameObject.ReferenceEquals( target.gameObject, GameplayController.instance.lastBox ))
                {
                    Invoke("WaitBox",1);
                    

                } else {
                    gameOver = true;
                    GameplayController.instance.GameOver();
                }

            }
        } 

    void OnTriggerEnter2D(Collider2D target) {
        // if(ignoreTrigger) return;
        if(target.tag == "GameOver"){
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            GameplayController.instance.GameOver();
        }
    }


}
