using UnityEngine;
using System.Collections;

public class InfoFly : MonoBehaviour {

	private float damage;
	private float hp;
	private bool isDie;

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		isDie = false;
		setDamage ();
	}
	
	// Update is called once per frame
	void Update () {
		if(hp < 0 && !isDie){
			isDie = true;
			Instantiate(explosion, transform.position, Quaternion.identity);
			ScoreManager.score += 1;
			Destroy(gameObject, 0.001f);
		}
	}

	public float getDamage(){
		return damage;
	}
	public void SetHp(float valueHp){
		hp = valueHp;
	}
	void setDamage(){
		switch (gameObject.name) {
		case "BlackFly(Clone)":
			damage = GetComponent<BlackFly> ().damageFlyBlack;
			hp = GetComponent<BlackFly> ().hpFlyBlack;
			break;
		case "BlueFly(Clone)":
			damage = GetComponent<BlueFly> ().damageFlyBlue;
			hp = GetComponent<BlueFly> ().hpFlyBlue;
			break;
		case "RedFly(Clone)":
			damage = GetComponent<RedFly> ().damageFlyRed;
			hp = GetComponent<RedFly> ().hpFlyRed;
			break;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		float damageBulletPlayer = 0;
		if(col.gameObject.tag == "bulletPlayer"){
			damageBulletPlayer = col.gameObject.GetComponent<BulletPlayer>().damagePlayer;
			Destroy(col.gameObject);
		}
		if(damageBulletPlayer != 0){
			hp -= damageBulletPlayer;
		}
	}
	
}
