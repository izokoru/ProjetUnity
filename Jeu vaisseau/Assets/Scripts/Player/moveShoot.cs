using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;

    private Vector3 siz;

    public Vector2 velocite;

    public GameObject explosionAsteroidePrefab;




    // Start is called before the first frame update
    void Start()
    {
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,1,0));
        explosionAsteroidePrefab = Resources.Load("Prefabs/ExplAsteroide", typeof(GameObject)) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = velocite;
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        if(transform.position.x > rightTopCameraBorder.x + (siz.x / 2)){
            Destroy(this.gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        GameObject go = col.gameObject;

        if(go.tag == "asteroides"){

            // On récupère la position de l'asteroide
			Vector3 tmp = new Vector3(transform.position.x + siz.x, transform.position.y, transform.position.z);

			GameObject gm = Instantiate(explosionAsteroidePrefab, tmp, Quaternion.identity) as GameObject;
            soundState.getInstance().shootAsteroide();
					
            Destroy(go);
            Destroy(this.gameObject);
            gameState.getInstance().addScore(100);
        }

        if(go.tag == "vaisseaux"){
            // On récupère la position du vaisseau
			Vector3 tmp = new Vector3(transform.position.x + siz.x, transform.position.y, transform.position.z);

			GameObject gm = Instantiate(explosionAsteroidePrefab, tmp, Quaternion.identity) as GameObject;
            soundState.getInstance().shootAsteroide();
            Destroy(go);
            Destroy(this.gameObject);

            gameState.getInstance().addScore(200);

        }
        
    }




}
