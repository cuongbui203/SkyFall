using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIFly : MonoBehaviour {
	public Vector3 posBulletAIFly;
	FactoryBullet factoryBullet;
	public AIFly(){
		factoryBullet = new FactoryBullet ();
	}
	public void UpDown(Rigidbody2D rigi, float speed){
		rigi.velocity = -Vector2.up * speed;
	}	
	public void RightLeft(Rigidbody2D rigi, float speed){
		rigi.velocity = -Vector2.right * speed;
	}
	public void Way(string way){
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (way), "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
	}
	public IEnumerator ShootTest(GameObject bullet, float fireRate){
		Instantiate (bullet, posBulletAIFly, Quaternion.identity);
		yield return new WaitForSeconds(fireRate);
		StartCoroutine (ShootTest( bullet, fireRate));
	}
	public IEnumerator Shoot(List<GameObject> listBullet, float fireRate){
		while(true){
			int bulletRandom;
			bulletRandom = Random.Range(0, listBullet.Count);
			factoryBullet.InstantiateBullet(listBullet[bulletRandom].name, posBulletAIFly);
			yield return new WaitForSeconds (fireRate);
		}
	}
	public string SelectWay(){
		int way = 0;
		way = Random.Range (0, 5);
		string myWay;
		switch(way){
		case 1 :
			myWay = "BlueWay";
			break;
		case 2 :
			myWay = "RedWay";
			break;
		case 3 :
			myWay = "BlackWay";
			break;
		case 4 :
			myWay = "UpDown";
			break;
		default :
			myWay = "UpDown";
			break;
		}
		return myWay;
	}
}
