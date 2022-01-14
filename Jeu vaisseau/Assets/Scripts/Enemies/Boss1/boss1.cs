using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{


    private Vector3 rightTopCameraBorder;

    private Vector2 siz;
    public GameObject etincellePrefab;


    // Start is called before the first frame update
    void Start()
    {
        rightTopCameraBorder = new Vector3(1,1,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){

        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;


        if(col.gameObject.tag == "shootJoueur"){
            // On cherche à savoir quel box a été touchée donc on parcourt toutes les box du gameObject
            Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
            for(int i = 0; i < colliders.Length; i++){
                if(col.IsTouching(colliders[i])){
                    // Position du boxCollider
                    Vector2 position = new Vector2(colliders[i].bounds.min.x - colliders[i].bounds.extents.x,
                     colliders[i].bounds.min.y + colliders[i].bounds.extents.y);
                    Vector2 position2 = new Vector2(colliders[i].bounds.center.x, colliders[i].bounds.center.y);                 
                    // Play sound explosion large
                    soundState.getInstance().explosionLarge();
                    Instantiate(Resources.Load("Prefabs/ExplAsteroide"), position, Quaternion.identity);
                    colliders[i].isTrigger = false;

                    GameObject go = Instantiate(etincellePrefab, position2, Quaternion.identity) as GameObject;
                    go.transform.parent = this.transform;
                }
            }
            //Destroy(col.gameObject);
        }
    }
}
