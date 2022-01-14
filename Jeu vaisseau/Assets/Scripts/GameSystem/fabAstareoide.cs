using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Gestion de la fabrique d'astéroides (a.k.a le déroulement du jeu)
public class fabAstareoide : MonoBehaviour{

    public GameObject asteroidPrefab;
    private int nbAsteroidesMax;
    private int nbAsteroides;
    private static fabAstareoide instance;


    // Start is called before the first frame update
    void Start()
    {
        this.nbAsteroidesMax = 2;
        
    }


    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }


    public void setNbAsteroidesMax(int nb){
        this.nbAsteroidesMax = nb;
    }

    public static fabAstareoide getInstance(){
        return instance;
    }

    // Update is called once per frame
    void Update(){
        nbAsteroides = GameObject.FindGameObjectsWithTag("asteroides").Length;

        if(nbAsteroides < nbAsteroidesMax){
            int tmp = nbAsteroidesMax - nbAsteroides;
            for(int i = 0; i < tmp; i++){
                GameObject go =  Instantiate(asteroidPrefab) as GameObject;
            }
        }
    }


    public int getNbAsteroides(){
        return this.nbAsteroides;
    }
}
