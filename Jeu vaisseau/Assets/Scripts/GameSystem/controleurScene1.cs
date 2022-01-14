using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleurScene1 : MonoBehaviour
{

    private fabAstareoide fabAstareoide;
    public fabriqueEnemies fabEnemies;

    public fabriqueBonus fabBonus;
    public fabriqueBoss fabriqueBoss;

    private static controleurScene1 instance;

    public AudioClip musiqueBoss;
    
    private int startFrame;

    public int currentFrame;
    void Awake()
    {
        if(instance == null){
            fabAstareoide = fabAstareoide.getInstance();
            //fabEnemies = fabriqueEnemies.getInstance();
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    void Start(){
        startFrame = Time.frameCount;
    }
    public static controleurScene1 getInstance(){
        return instance;
    }
    void Update() {
        // Gestion de l'apparition des ennemis

        if(GameObject.FindGameObjectWithTag("ship").GetComponent<posShip>().getiSDead()){
            Destroy(GameObject.Find("Background"));
            GameObject.Find("TransitionScene").GetComponent<transitionScene>().loadNextLevel("gameOver");
        }

        /* Liste des frames où sont créés les bonus
        - 1000 DShoot
        - 5000 Soin
        - 10000 DShoot
        - 15000 DShoot
        - 25000 Fire Rate
        - 40000 Soin
        - 61000 Soin
        - 62000 Fire Rate
        */
        
        // On récupère la frame actuelle par rapport au commencement de la scene
        currentFrame = Time.frameCount - startFrame;
        if(currentFrame == 1000){
            fabBonus.creerBonusDoubleShoot();
        }
        if(currentFrame == 5000){
            fabBonus.creerBonusSoin();
        }
        if(currentFrame == 10000){
            fabBonus.creerBonusDoubleShoot();
        }
        if(10000 <= currentFrame && currentFrame < 15000){
            fabAstareoide.setNbAsteroidesMax(3);
            fabEnemies.setNbVaisseauxMax(1);
        }
        if(currentFrame == 15000){
            fabBonus.creerBonusDoubleShoot();
        }
        if(currentFrame == 25000){
            fabBonus.creerBonusFireRate();
        }
        if( 15000 < currentFrame && currentFrame < 30000){
            fabAstareoide.setNbAsteroidesMax(4);
            moveAsteroid.velociteMax = 6.0f;
        }
        if(currentFrame == 40000){
            fabBonus.creerBonusSoin();
        }
        if(40000 < currentFrame && currentFrame < 50000){
            fabAstareoide.setNbAsteroidesMax(5);
            fabEnemies.setNbVaisseauxMax(1);
        }
        if(currentFrame == 50000){
            GameObject go = GameObject.FindGameObjectWithTag("MainCamera");
            go.transform.GetChild(0).GetComponent<AudioSource>().clip = musiqueBoss;
            go.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        if(currentFrame == 59000){
            fabriqueBoss.setNbBossMax(1);
        }
        if(59500 < currentFrame){
            // Apparition du boss
            fabAstareoide.setNbAsteroidesMax(3);
            fabEnemies.setNbVaisseauxMax(0);

            if(GameObject.FindGameObjectWithTag("boss1") == null){
                Destroy(GameObject.Find("Background"));
                GameObject.Find("TransitionScene").GetComponent<transitionScene>().loadNextLevel("gameOver");
            }

        }
        if(currentFrame == 61000){
            fabBonus.creerBonusSoin();
        }
        if(currentFrame == 62000){
            fabBonus.creerBonusFireRate();
        }


        
    }
}
