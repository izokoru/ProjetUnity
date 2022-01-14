using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    Material material;
    public int xVelocity, yVelocity;
    Vector2 offset;

    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Start(){
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * (Time.deltaTime / 10);
    }

    public void setMaterial(Material material){
        this.material = material;
    }
}
