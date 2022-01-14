using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{

    private PlayerData data;
    // Start is called before the first frame update
    void Awake(){

        if(SaveSystem.loaded){
            data = SaveSystem.loadPlayer("test");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerData getPlayerData(){
        return this.data;
    }
}
