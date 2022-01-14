using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private static Player instance;
    public GameObject ship; 

    public Background bg;
    
    void Awake(){
        if(instance == null){
            // On charge la partie
            
            Debug.Log("Objet a été créé !");
            instance = this;
            Instantiate(ship);
            Instantiate(bg);
            //DontDestroyOnLoad(this.gameObject);
        }
        else{
            Debug.Log("Objet déjà créé !");
            Destroy(this);
        }
    }
    public static Player getInstance(){
        return instance;
    }



}

    
