using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public string level;
    public int health;
    public int score;
    public int money = 0;



    public PlayerData(Player player){
        // GameObject ship 
        GameObject ship = player.ship.gameObject.transform.GetChild(0).gameObject;

        // Script posShip
        posShip scriptPosShip = ship.GetComponent<posShip>();
        

        level = "Level2";
        health = 1;
        score = 400;

    }


}
