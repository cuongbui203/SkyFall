using UnityEngine;
using System.Collections;

public class InfoBullet : MonoBehaviour {
	private float damage;
	private float hd;
	// Use this for initialization
	void Start () {
		setDamage ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(){

	}
	public float getDamage(){
		return damage;
	}
	void setDamage(){
		switch(gameObject.name){
		case "BlackBullet(Clone)":
			damage = GetComponent<BlackBullet>().damageBulletBlack;
			
			break;
		case "BlueBullet(Clone)":

			damage = GetComponent<BlueBullet>().damageBulletBlue;
			
			break;
		case "GrayBullet(Clone)":
			damage = GetComponent<GrayBullet>().damageBulletGray;
			
			break;
		case "OrangeBullet(Clone)":
			damage = GetComponent<OrangeBullet>().damageBulletOrange;
			
			break;
		case "RedBullet(Clone)":
			damage = GetComponent<RedBullet>().damageBulletRed;
			
			break;
		}
	}
}
