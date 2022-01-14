using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour
{
	private Vector3 leftTopCameraBorder;

    private Vector3 coteDroit;

    private Vector3 siz;

    private Vector2 velocite;

    public static float velociteMax = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Calcul des angles avec conversion du monde de la caméra au monde du pixel pour 
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,1,0));
        
        coteDroit = Camera.main.ViewportToWorldPoint(new Vector3(1.05f, Random.Range(0.0f, 100.0f) / 100, 0));

        GetComponent<Rigidbody2D>().position = coteDroit;

        velocite = new Vector2(-(Random.Range(5.0f, velociteMax)), 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        GetComponent<Rigidbody2D>().velocity = velocite;

        if (transform.position.x < leftTopCameraBorder.x + (siz.x / 2))
		{
			Destroy(gameObject);
		}
        
    }

    




}
