using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVaisseau : MonoBehaviour
{

    private Vector3 leftTopCameraBorder;
    private Vector3 siz;
    public Vector2 velocite;
    public int nbShootRestant = 1;
    private float delaiB4Shoot = 2.0f;
    private shootVaisseau shootVaisseau;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Création du vaisseau..");
        leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,1,0));
        Vector3 coteDroit = Camera.main.ViewportToWorldPoint(new Vector3(1.05f, Random.Range(0f, 1f), 10f));
        transform.position = coteDroit;
        velocite = new Vector2(-4, 0);
        shootVaisseau = gameObject.GetComponent<shootVaisseau>() as shootVaisseau;
        
    }

    // Update is called once per frame
    void Update()
    {
        // On récupère la taille du sprite même s'il est déformé
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        
        GetComponent<Rigidbody2D>().velocity = velocite;

        if(transform.position.x < leftTopCameraBorder.x + (siz.x / 2)){
            Destroy(gameObject);
        }

        if(this.nbShootRestant > 0){
            this.nbShootRestant -= 1;
            StartCoroutine(this.delaiShoot());
        }
    }


    // Delai avant que le vaisseau tire un laser
    private IEnumerator delaiShoot(){
        yield return new WaitForSeconds(this.delaiB4Shoot);
        shootVaisseau.tirer();
    }
}
