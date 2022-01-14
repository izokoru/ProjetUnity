using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShootBoss1 : MonoBehaviour
{
    private Vector3 leftTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 siz;

    public Vector2 velocite;
    
    // Start is called before the first frame update
    void Start()
    {
        leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,1,0));
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,0,0));

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = velocite;
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        if(transform.position.x < leftTopCameraBorder.x + (siz.x / 2)){
            Destroy(this.gameObject);
        }
        if(transform.position.y < leftBottomCameraBorder.y + (siz.y / 2)){
             Destroy(this.gameObject);           
        }
        if(transform.position.y > leftTopCameraBorder.y + (siz.y / 2)){
            Destroy(this.gameObject);
        }
        
    }
}
