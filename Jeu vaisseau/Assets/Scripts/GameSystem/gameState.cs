using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour
{
    Material level2Material;
    private int scorePlayer = 0;

    private static gameState instance;


    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            if(SaveSystem.loaded){
                PlayerData data = GameObject.FindGameObjectWithTag("controleurJeu").gameObject.GetComponent<LoadSystem>().getPlayerData();
                Debug.Log(data);
                scorePlayer = data.score;
            }

        }
        else{
            Destroy(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(GameObject.FindWithTag("scoreLabel") != null){
            GameObject.FindWithTag("scoreLabel").GetComponent<Text>().text = "Score: " + scorePlayer;
        }
    }

    void Update(){
        
       
    }

    public void addScore(int score){
        this.scorePlayer += score;
    }

    public static gameState getInstance(){
        return gameState.instance;
    }

    public int getScorePlayer(){
        return this.scorePlayer;
    }

    public void setBackground(string name){
        switch(name){
            case "Level2":
                GameObject gm = GameObject.FindGameObjectWithTag("background") as GameObject;
                gm.GetComponent<scroll>().setMaterial(level2Material);
                break;
        }
    }

    public static void loadLevel(string name){
        GameObject go = GameObject.FindGameObjectWithTag("ship");
        if(go != null){
            posShip pos = go.GetComponent<posShip>();
            if(pos.getiSDead()){
                Destroy(GameObject.Find("Background"));
                gameState.loadLevel(name);
            }
        }
        GameObject.Find("TransitionScene").GetComponent<transitionScene>().loadNextLevel(name);
    }
}
