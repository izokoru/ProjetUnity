using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shootAgain : MonoBehaviour
{
    private Vector2 siz;

    public GameObject shootPrefab;

    public float fireRate;

    private float nextShoot = 0.0f;

    private bool bonusDoubleShoot;

    public bool bonusFireRate = false;

    void Start(){
        this.bonusDoubleShoot = false;
        this.bonusFireRate = false;
    }


    // Update is called once per frame
    void Update()
    {
        // On récupère la taille de l'objet dont le script est attaché
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        bool sp = Input.GetKeyDown(KeyCode.Space);
        if(sp && Time.time > nextShoot){

            // Pour la cadence de tir
            if(bonusFireRate){
                nextShoot = Time.time + (fireRate / 2);
            }
            else{
                nextShoot = Time.time + fireRate;
            }

            // Si le bonus double shoot est activé on tire 2 fois 
            if(bonusDoubleShoot){
                
                // On récupère la position du vaisseau
                Vector3 tmp1 = new Vector3(transform.position.x + siz.x, (transform.position.y - 0.25f * transform.position.y), transform.position.z);
                Vector3 tmp2 = new Vector3(transform.position.x + siz.x, (transform.position.y + 0.25f * transform.position.y), transform.position.z);
                
                Instantiate(shootPrefab, tmp1, Quaternion.identity);
                Instantiate(shootPrefab, tmp2, Quaternion.identity);
                soundState.getInstance().spaceShoot();
            }


            else{
                
                // On récupère la position du vaisseau
                Vector3 tmp = new Vector3(transform.position.x + siz.x, transform.position.y, transform.position.z);
                GameObject go = Instantiate(shootPrefab, tmp, Quaternion.identity) as GameObject;

                soundState.getInstance().spaceShoot();
            }
            
        }
        

    }

    public void setBonusDoubleShoot(bool bonus){
        this.bonusDoubleShoot = bonus;
    }

    public bool getBonusDoubleShoot(){
        return this.bonusDoubleShoot;
    }
}
