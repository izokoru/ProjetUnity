using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootVaisseau : MonoBehaviour
{
    /// Composant du vaisseau ennemi qui gère la création du shoot


    private Vector2 siz;

    public GameObject laserShootPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void tirer(){
        // On récupère la taille de l'objet dont le script est attaché
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        
        Vector3 postionVaisseau = new Vector3(transform.position.x - siz.x, transform.position.y, transform.position.z);
        Instantiate(laserShootPrefab, postionVaisseau, Quaternion.identity);
        soundState.getInstance().shootVaisseau();
    }

   
}
