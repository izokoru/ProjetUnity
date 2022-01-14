using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Gestionnaire de sons
public class soundState : MonoBehaviour
{
    public AudioSource playerShotSound;

    public AudioSource collisionSound;

    public AudioSource shootAsteroideSound;

    public AudioSource shootVaisseauSound;

    public AudioSource musiqueBossSound;

    public AudioSource bonusSound;

    public AudioSource gameOverSound;

    public AudioSource explosionLargeSound;

    public AudioSource shootBossPetitCanon1Sound;
    
    private static soundState instance;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this);
        }
    }
    // Update is called once per frame
    void Update(){
        
    }

    public void spaceShoot(){
        playerShotSound.Play();
    }

    public void collision(){
        collisionSound.Play();
    }

    public void shootAsteroide(){
        shootAsteroideSound.Play();
    }

    public void shootVaisseau(){
        shootVaisseauSound.Play();
    }

    public void musiqueBoss(){
        musiqueBossSound.Play();
    }

    public void getBonus(){
        bonusSound.Play();
    }

    public void gameOver(){
        gameOverSound.Play();
    }

    public void explosionLarge(){
        explosionLargeSound.Play();
    }

    public void shootBossPetitCanon1(){
        shootBossPetitCanon1Sound.Play();
    }

    private void MakeSound(AudioClip audio){
        AudioSource.PlayClipAtPoint(audio, transform.position);
    }

    

    public static soundState getInstance(){
        return soundState.instance;
    }
}
