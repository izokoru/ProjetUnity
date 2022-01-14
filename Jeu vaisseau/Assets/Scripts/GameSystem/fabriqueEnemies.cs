using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabriqueEnemies : MonoBehaviour
{

    private int nbVaisseauxMax;
    private static fabriqueEnemies instance;
    public GameObject fabVaisseaux;
    private int nbVaisseaux;

    void Awake(){
        if(instance == null){
            instance = this;
            //Debug.Log("Création fab ennemies");
        }
        else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nbVaisseauxMax = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nbVaisseauxMax);
        nbVaisseaux = GameObject.FindGameObjectsWithTag("vaisseaux").Length;

        if(nbVaisseaux < nbVaisseauxMax){
            int tmp = nbVaisseauxMax - nbVaisseaux;
            for(int i = 0; i < tmp; i++){
                GameObject go = Instantiate(fabVaisseaux) as GameObject;
            }
        }
        
    }


    public void setNbVaisseauxMax(int nb){
        this.nbVaisseauxMax = nb;
    }

    public static fabriqueEnemies getInstance(){
        return instance;
    }

    public int getNbVaisseaux(){
        return this.nbVaisseaux;
    }
}
