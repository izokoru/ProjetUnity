using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour
{
	public GameObject modele;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	
	private Vector3 siz;

	private int maxHealth = 2;
	private int currHealth;

	public healthBar healthBar;

	private bool estTouche = false;

	private bool isDead = false;

	private float invincibilityDuration = 2.5f;

	private float invincibilityDeltaTime = 0.15f;

	// On ajoute le prefab
    public GameObject explosionAsteroidePrefab;

	public void setHealth(){
		currHealth = 1;
	}
    // Start is called before the first frame update
    void Start()
    {
		// Calcul des angles avec conversion du monde de la caméra au monde du pixel pour 
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,1,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,1,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1,0,0));
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0,0,0));
		this.currHealth = maxHealth;

	
		healthBar.setMaxHealth(maxHealth);
		

		if(SaveSystem.loaded){

			// TODO get playerdata et load

			PlayerData data = GameObject.FindGameObjectWithTag("controleurJeu").gameObject.GetComponent<LoadSystem>().getPlayerData();
			Debug.Log(data.health);

			currHealth = data.health;

			healthBar.setHealth(currHealth);

			Debug.Log("Chargement fini");
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(this.currHealth <= 0){
			this.isDead = true;
		}

		siz.x = gameObject.GetComponent<SpriteRenderer>() .bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer>() .bounds.size.y;
		
		
		if( transform.position.y < leftBottomCameraBorder.y + (siz.y / 2)) {
			gameObject.transform.position = new Vector3(transform.position.x, leftBottomCameraBorder.y + (siz.y / 2), transform.position.z);
		}
		if(transform.position.y > rightTopCameraBorder.y - (siz.y / 2)) {
			gameObject.transform.position = new Vector3(transform.position.x, rightTopCameraBorder.y - (siz.y / 2), transform.position.z);
		}
		if(transform.position.x < leftTopCameraBorder.x + (siz.x / 2)) {
			gameObject.transform.position = new Vector3(leftTopCameraBorder.x + (siz.x / 2), transform.position.y, transform.position.z);
		}
		if(transform.position.x > rightBottomCameraBorder.x - (siz.x / 2)) {
			gameObject.transform.position = new Vector3(rightBottomCameraBorder.x - (siz.x / 2), transform.position.y, transform.position.z);
		}
	}

	public void setTouche(bool estTouche){
		this.estTouche = estTouche;
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "bonusDoubleShoot"){
			soundState.getInstance().getBonus();
			this.takeBonus("bonusDoubleShoot");
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "soin"){
			soundState.getInstance().getBonus();
			this.takeBonus("soin");
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "fireRate"){
			soundState.getInstance().getBonus();
			this.takeBonus("fireRate");
			Destroy(col.gameObject);
		}

		// Si on est touché c'est qu'on est invulnérable pendant 3 secondes
		if(!estTouche){
			string tagTmp = col.gameObject.tag;
			
			switch(tagTmp){
				case "asteroides":
					soundState.getInstance().collision();
					takeDamage(tagTmp);

					// On récupère la position de l'asteroide
					Vector3 tmp = new Vector3(transform.position.x, transform.position.y, transform.position.z);

					GameObject go = Instantiate(explosionAsteroidePrefab, tmp, Quaternion.identity) as GameObject;
					Destroy(col.gameObject);
					StartCoroutine(this.BecomeInvincible());
					break;
				case "vaisseaux":
					soundState.getInstance().collision();
					takeDamage(tagTmp);

					// On récupère la position du vaisseau
					Vector3 tmp2 = new Vector3(transform.position.x, transform.position.y, transform.position.z);

					GameObject go2 = Instantiate(explosionAsteroidePrefab, tmp2, Quaternion.identity) as GameObject;
					Destroy(col.gameObject);
					StartCoroutine(this.BecomeInvincible());
					break;

				case "tirVaisseau":
					soundState.getInstance().collision();
					takeDamage("tirVaisseau");

					Destroy(col.gameObject);
					StartCoroutine(this.BecomeInvincible());
					break;	

				case "shootBoss":
					soundState.getInstance().collision();
					takeDamage("shootBoss");

					Destroy(col.gameObject);
					StartCoroutine(this.BecomeInvincible());
					break;
			}
		}
	}

	public int getHealth(){
		return this.currHealth;
	}

	public bool getiSDead(){
		return this.isDead;
	}

	private void takeDamage(string tmpTag){

		switch(tmpTag){
			case "asteroides":
				this.currHealth -= 1;
				healthBar.setHealth(currHealth);
				break;

			case "tirVaisseau":
				this.currHealth -= 1;
				healthBar.setHealth(currHealth);
				break;
			case "vaisseaux":
				this.currHealth -= 1;
				healthBar.setHealth(currHealth);
				break;

			case "shootBoss":
				this.currHealth -= 1;
				healthBar.setHealth(currHealth);
				break;

		}

		if(currHealth <= 0){
			isDead = true;
		}
	}

	private void takeBonus(string tag){
		switch(tag){
			case "bonusDoubleShoot":
				gameObject.GetComponent<shootAgain>().setBonusDoubleShoot(true);
				StartCoroutine(this.ActivateBonus());

				break;

			case "soin":
				this.currHealth += 2;
				if(currHealth > maxHealth){
					currHealth = maxHealth;
				}
				healthBar.setHealth(currHealth);
				break;

			case "fireRate":
				this.gameObject.GetComponent<shootAgain>().bonusFireRate = true;
				StartCoroutine(this.ActivateFireRateBonus());
				break;
		}
	}

	private IEnumerator ActivateBonus(){
		// On attend 4 secondes (la durée du bonus) avant de le désactiver
		yield return new WaitForSeconds(4f);

		if(gameObject.GetComponent<shootAgain>().getBonusDoubleShoot()){
			gameObject.GetComponent<shootAgain>().setBonusDoubleShoot(false);
		}

	}

	private IEnumerator ActivateFireRateBonus(){
		// On attend 4 secondes (la durée du bonus) avant de le désactiver
		yield return new WaitForSeconds(4f);

		if(gameObject.GetComponent<shootAgain>().bonusFireRate){
			gameObject.GetComponent<shootAgain>().bonusFireRate = false;
		}


	}


	// Animation quand le joueur est touché
	private IEnumerator BecomeInvincible(){
		// On devient invulnérable
		this.setTouche(true);

		for(float i = 0; i < this.invincibilityDuration; i += invincibilityDeltaTime){
			
			// Pour faire clignoter le joueur quand il est touché
			if(modele.transform.localScale == Vector3.one){
				this.scaleModel(Vector3.zero);
			}
			else{
				this.scaleModel(Vector3.one);
			}



			yield return new WaitForSeconds(this.invincibilityDeltaTime);
		}

		this.scaleModel(Vector3.one);

		this.setTouche(false);

	}

	private void scaleModel(Vector3 scale){
		modele.transform.localScale = scale;
	}

}
