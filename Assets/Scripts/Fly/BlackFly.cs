using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BlackFly : AIFly, Observer{

	public float hpFlyBlack;
	public float damageFlyBlack;
	public float speedFlyBlack;
	private Rigidbody2D rigi;
	public Transform posBullet;
	public GameObject prefabBullet;
	public float fireRate;
	private bool isUpDown;
	private string way;

	public List<GameObject> listPrefabBullet;

	void Start(){
		GameController.flo.Subscribe (this);
		rigi = GetComponent<Rigidbody2D>();
		posBulletAIFly = posBullet.position;
		StartCoroutine (Shoot(listPrefabBullet, fireRate));
		way = SelectWay ();
		if (way.Equals ("UpDown")) {
			isUpDown = true;
		} else {
			isUpDown = false;
			Way(way);
		}
		//BulletTrajectory ();
	}
	void FixedUpdate(){
		posBulletAIFly = posBullet.position;
		if(isUpDown){
			UpDown (rigi, speedFlyBlack);
		}
	}
	public void BulletTrajectory(){
		//iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("BlueWay"), "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
		UpDown (rigi, speedFlyBlack);
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
