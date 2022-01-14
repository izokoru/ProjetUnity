using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShootEnnemi : MonoBehaviour {

    private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
    private Vector3 siz;
    private int speed;
    private Vector2 shipPos;
    private Vector2 posDepart;
    private Vector2 direction;
    private float angle;


    // Start is called before the first frame update
    void Start() {

		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,1,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,1,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,0,0));
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,0,0));

        
        // Récupérer la position du ship afin de calculer la vélocité
        shipPos = GameObject.FindGameObjectWithTag("ship").gameObject.transform.position;
        

        // Vitesse de la balle
        speed = 5;
        
        // Rotation du sprite en direction du ship
        posDepart = transform.position;
        direction = shipPos - posDepart;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
             
    }

    // Update is called once per frame
    void Update() {
    
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        transform.position = Vector3.MoveTowards(transform.position, shipPos, Time.deltaTime * speed);

        if( transform.position.y < leftBottomCameraBorder.y + (siz.y / 2)) {
            Destroy(gameObject);
        }
		if(transform.position.y > rightTopCameraBorder.y - (siz.y / 2)){
            Destroy(gameObject);
		}
		if (transform.position.x < leftTopCameraBorder.x + (siz.x / 2)) {
            Destroy(gameObject);
		}
		if (transform.position.x > rightBottomCameraBorder.x - (siz.x / 2)) {
            Destroy(gameObject);
		}
        if( transform.position.x == shipPos.x && transform.position.y == shipPos.y){
            Destroy(gameObject);
        }



    }
}
