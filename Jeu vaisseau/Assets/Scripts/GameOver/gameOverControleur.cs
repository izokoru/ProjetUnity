using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverControleur : MonoBehaviour
{
    public GameObject score;
    public TextMeshProUGUI texteScore;
    // Start is called before the first frame update
    void Start() {
        texteScore.text = "Score: " + gameState.getInstance().getScorePlayer();
        
    }

    public void goToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
