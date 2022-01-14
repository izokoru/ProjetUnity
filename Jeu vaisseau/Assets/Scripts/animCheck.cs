using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animCheck : MonoBehaviour
{

    private int nb;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {   
        nb = this.gameObject.transform.childCount;
        if(nb == 0){
            Destroy(this.gameObject);
        }
    }
}
