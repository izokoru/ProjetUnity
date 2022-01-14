using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabriqueBonus : MonoBehaviour
{

    public GameObject prefabBonusDoubleshoot;

    public GameObject prefabBonusSoin;

    public GameObject prefabBonusFireRate;
    private static fabriqueBonus instance;



    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    public void creerBonusDoubleShoot(){
        Instantiate(prefabBonusDoubleshoot);
    }

    public void creerBonusSoin(){
        Instantiate(prefabBonusSoin);
    }

    public void creerBonusFireRate(){
        Instantiate(prefabBonusFireRate);
    }
    public static fabriqueBonus getInstance(){
        return instance;
    }
}
