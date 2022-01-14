using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBoss1 : MonoBehaviour
{
    private float nextShootPetitCanon;
    private float nextShootCanonSecondaire;
    public float fireRatePetitCanon;

    private float nextShootGrosCanon;

    public float fireRateNextShootGrosCanon;

    public float fireRateShootCanonSecondaire;
    public GameObject shootBoss1Prefab;
    public BoxCollider2D lastHitBox;
    private int nbHitboxActives = 0;
    private bool hasBeenTriggered = false;
    public GameObject explosionBoss;

    private int nbExplosions = 0;
    private bool enCours;

    // Start is called before the first frame update
    void Start()
    {
        /*
        BoxCollider2D[] posShootDepart = this.gameObject.GetComponents<BoxCollider2D>();
        for(int i = 0; i < posShootDepart.Length; i++){
            posShootDepart[i].isTrigger = false;
        }
        lastHitBox.isTrigger = true;
        hasBeenTriggered = true;
        */
    }

    // Update is called once per frame
    void Update() {
        nbHitboxActives = 0;
        if(hasBeenTriggered == false && lastHitBox.isTrigger == false && Time.time > nextShootPetitCanon){
            // Cadence de tir
            nextShootPetitCanon = Time.time + fireRatePetitCanon;

            // Récupérer les BoxCollider2d afin de trouver la position du départ de tir
            BoxCollider2D[] posShootDepart = this.gameObject.GetComponents<BoxCollider2D>();

            for(int i = 0; i < posShootDepart.Length; i++){
                Vector2 posShoot = new Vector2(posShootDepart[i].bounds.center.x - posShootDepart[i].bounds.extents.x,
                posShootDepart[i].bounds.center.y);

                Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity);
                soundState.getInstance().shootBossPetitCanon1();
            }
        }

        if(lastHitBox.isTrigger && Time.time > nextShootPetitCanon){
            nextShootPetitCanon = Time.time + fireRatePetitCanon;

            // Récupérer la BoxCollider2d afin de trouver la position du départ de tir
            BoxCollider2D[] posShootDepart = this.gameObject.GetComponents<BoxCollider2D>();

            for(int i = 0; i < posShootDepart.Length; i++){
                if(posShootDepart[i].isTrigger){
                    if(Time.time > nextShootGrosCanon){
                        // Plus grosse salve de tirs
                        nextShootGrosCanon = Time.time + fireRateNextShootGrosCanon;
                        Vector2 posShoot = new Vector2(posShootDepart[i].bounds.center.x - posShootDepart[i].bounds.extents.x,
                        posShootDepart[i].bounds.center.y);

                        GameObject go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;

                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, 2);


                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, -2);

                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, 1.5f);

                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, -1.5f);

                        soundState.getInstance().shootBossPetitCanon1();
                    }
                    else{
                        Vector2 posShoot = new Vector2(posShootDepart[i].bounds.center.x - posShootDepart[i].bounds.extents.x,
                        posShootDepart[i].bounds.center.y);

                        GameObject go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;

                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, 2);


                        go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                        go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, -2);

                        soundState.getInstance().shootBossPetitCanon1();
                    }
                    
                }
            }
        }
        if(lastHitBox.isTrigger && Time.time > nextShootCanonSecondaire){
            nextShootCanonSecondaire = Time.time + fireRateShootCanonSecondaire;

            // Récupérer la BoxCollider2d afin de trouver la position du départ de tir
            BoxCollider2D[] posShootDepart = this.gameObject.GetComponents<BoxCollider2D>();
            for(int i = 0; i < posShootDepart.Length; i++){
                if(!posShootDepart[i].isTrigger){
                    Vector2 posShoot = new Vector2(posShootDepart[i].bounds.center.x - posShootDepart[i].bounds.extents.x,
                    posShootDepart[i].bounds.center.y);

                    GameObject go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;

                    go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                    go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, 2);


                    go = Instantiate(shootBoss1Prefab, posShoot, Quaternion.identity) as GameObject;
                    go.GetComponent<moveShootBoss1>().velocite = new Vector2(-4, -2);

                    soundState.getInstance().shootBossPetitCanon1();
                }
            }
        }

        BoxCollider2D[] boxCollider2Ds = this.gameObject.GetComponents<BoxCollider2D>();
        for(int i = 0; i < boxCollider2Ds.Length; i++){
            if(boxCollider2Ds[i].isTrigger){
                nbHitboxActives += 1;
            }
        }
        if(nbHitboxActives == 0 && hasBeenTriggered == false){
            lastHitBox.isTrigger = true;
            hasBeenTriggered = true;
            nbHitboxActives = 1;
        }
        if(nbHitboxActives == 0 && hasBeenTriggered == true){
            if(nbExplosions == 0){
                fireRatePetitCanon = 100f;
            }
            // Destruction du boss
            if(enCours == false){
                StartCoroutine(detruireBoss());
            }
            if(nbExplosions == 13){
                gameState.getInstance().addScore(500);
                Destroy(this.gameObject);
                gameState.loadLevel("GameOver");
                //GameObject.Find("TransitionScene").GetComponent<transitionScene>().loadNextLevel("gameOver");
            }
            
        }
        
    }

    private IEnumerator detruireBoss(){
        enCours = true;

        Vector3 posBoss = transform.position;
        Vector2 siz = GetComponent<SpriteRenderer>().bounds.size;
        Vector2 posExpl = new Vector3(Random.Range(posBoss.x, siz.x), Random.Range(posBoss.y, siz.y), 10);

        yield return new WaitForSeconds(0.2f);
        if(nbExplosions % 3 == 0){
            soundState.getInstance().explosionLarge();
        }
        else{
            soundState.getInstance().shootAsteroide();
        }
        Instantiate(explosionBoss, posExpl, Quaternion.identity);

        nbExplosions++;

        enCours = false;
    }


}
