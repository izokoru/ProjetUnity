using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource selectionMenu;
    public AudioSource clicSelectionMenu;
    public void playGame(){
        SceneManager.LoadScene("Level1");
    }

    public void quitGame(){
        Application.Quit();
    }


    public void SoundSelectionMenu(){
        selectionMenu.Play();
    }

    public void SoundClicSelectionMenu(){
        clicSelectionMenu.Play();
    }

    public void loadGame(string save){
        SaveSystem.loaded = true;
        SceneManager.LoadScene("Level2");

    }

    void Start(){

        /*
        GameObject go = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
        Player player = go.GetComponent<Player>() as Player;
        posShip pos = player.ship.transform.GetChild(0).gameObject.GetComponent<posShip>() as posShip;
        pos.setHealth();
        
        //TODO finir load, voir comment save le score et save

        


        SaveSystem.SavePlayer(go.GetComponent<Player>() as Player);
        */
    }

}
