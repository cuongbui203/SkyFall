using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RedFly : AIFly, Observer{

	public float hpFlyRed;
	public float damageFlyRed;
	public float speedFlyRed;
	private Rigidbody2D rigi;
	public Transform posBullet;
	public float fireRate;
	public List<GameObject> listPrefabBullet;
	private bool isUpDown;
	private string way;

	void Start(){
		GameController.flo.Subscribe (this);
		rigi = GetComponent<Rigidbody2D>();
		posBulletAIFly = posBullet.position;
		StartCoroutine (Shoot( listPrefabBullet, fireRate));
		way = SelectWay ();
		if (way.Equals ("UpDown")) {
			isUpDown = true;
		} else {
			isUpDown = false;
			Way(way);
		}
	}
	void FixedUpdate(){
		posBulletAIFly = posBullet.position;
		if(isUpDown){
			UpDown (rigi, speedFlyRed);
		}
	}
	public RedFly(){
		//Debug.Log ("Red Fly");
	}
	public void GameEventClearScreen(){
		try{
			if(GetComponent<InfoFly>() != null){
				GetComponent<InfoFly>().SetHp(-10);
			}
		}catch {

		}
	}
}
