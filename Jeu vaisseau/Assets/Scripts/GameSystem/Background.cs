using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float startTime;
    public string currentTime;

    public string currentFrame;

    private static Background instance;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            transform.GetChild(0).gameObject.GetComponent<Canvas>().worldCamera = cam;
            
        }
        else{
            Destroy(this);
        }
    }

    public static Background getInstance(){
        return instance;
    }

    void Update(){
        startTime += Time.deltaTime;
        currentTime = string.Format ("{0:0.0}", startTime);
        currentFrame = "Frame: " + Time.frameCount;

        
    }

    void OnGUI(){
        GUI.Button(new Rect (10,10,40,20), currentTime);
        GUI.Button(new Rect (10,100,120,20), currentFrame);
    }
}
