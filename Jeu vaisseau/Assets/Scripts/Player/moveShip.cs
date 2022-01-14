using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour {

    public Vector2 speed;
    private Vector2 mouvement;

    public Animator animator;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update(){

        // Récupérer les axes
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        // Mouvement = vitesse * direction
        mouvement = new Vector2(speed.x * inputX, speed.y * inputY);

        if(inputX < 0){
            animator.SetBool("backward", true);
        }
        else{
            animator.SetBool("backward", false);
        }

        animator.SetFloat("speed", Mathf.Abs(mouvement.x));

        // Récupérer l'objet en mouvement
        GetComponent<Rigidbody2D>().velocity = mouvement;


        
    }
}
