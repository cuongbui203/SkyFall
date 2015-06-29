using UnityEngine;
using System.Collections;

public class RedBullet : MonoBehaviour, Bullet, Observer {
	private Rigidbody2D rigi;
	void Start(){
//		damage = damageBulletRed;
//		speed = speedBulletRed;
		GameController.flo.Subscribe (this);
		rigi = GetComponent<Rigidbody2D>();
	}
	public float speedBulletRed;
	public float damageBulletRed;
//	public float speed{
//		get{
//			return speedBulletRed;
//		}
//		set{
//			speedBulletRed = value;
//		}
//	}
//	public float damage{
//		get{
//			return damageBulletRed;
//		}
//		set{
//			damageBulletRed = value;
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		BulletTrajectory ();
	}
	
	//interface member implementation
	public void BulletTrajectory(){
		rigi.velocity = -Vector2.up * speedBulletRed;
	}
	public RedBullet(){
		//Debug.Log ("RedBullet");
	}
	public void GameEventClearScreen(){
		try{
			if(GetComponent<InfoBullet>() != null){
				Destroy(gameObject);
			}
		}catch {
			
		}
	}
}
