using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScene : MonoBehaviour
{
    public Animator transition;
    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void loadNextLevel(string name){
        StartCoroutine(this.loadLevel(name));
    }

    private IEnumerator loadLevel(string name){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(name);
    }
}
