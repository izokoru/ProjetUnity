using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoss : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;

    private Vector3 coteDroit;
    public Vector2 velocite;

    private Vector2 siz;
    // Start is called before the first frame update
    void Start() {

        rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,1,0));
        coteDroit = Camera.main.ViewportToWorldPoint (new Vector3(1.2f,0.5f,10));
        gameObject.transform.position = coteDroit;
    }

    // Update is called once per frame
    void Update()
    {
        siz.x = GetComponent<SpriteRenderer>().bounds.size.x;
        siz.y = GetComponent<SpriteRenderer>().bounds.size.y;
        GetComponent<Rigidbody2D>().velocity = velocite;
        if(transform.position.x <= (rightTopCameraBorder.x / 2)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }
}
