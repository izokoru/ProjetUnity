using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabriqueBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    private static fabriqueBoss instance;
    private int nbBoss;
    private int nbBossMax;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        nbBossMax = 0;
    }

    // Update is called once per frame
    void Update() {

        nbBoss = GameObject.FindGameObjectsWithTag("boss1").Length;

        if(nbBoss < nbBossMax){
            int tmp = nbBossMax - nbBoss;
            for(int i = 0; i < tmp; i++){
                Instantiate(bossPrefab);
            }
        }
        
    }

    public void setNbBossMax(int nb){
        nbBossMax = nb;
    }

    public static fabriqueBoss getInstance(){
        return instance;
    }
}
