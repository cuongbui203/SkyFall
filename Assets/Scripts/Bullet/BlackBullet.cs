using UnityEngine;
using System.Collections;

public class BlackBullet : MonoBehaviour, Bullet, Observer  {
	private Rigidbody2D rigi;
	public float speedBulletBlack;
	public float damageBulletBlack;
//	public float speed{
//		get{
//			return speedBulletBlack;
//		}
//		set{
//			speedBulletBlack = value;
//		}
//	}
//	public float damage{
//		get{
//
//			return damageBulletBlack;
//		}
//		set{
//			damageBulletBlack = value;
//		}
//	}

	void Start(){
//		damage = damageBulletBlack;
//		speed = speedBulletBlack;
		rigi = GetComponent<Rigidbody2D>();
		GameController.flo.Subscribe (this);
	}
	
	// Update is called once per frame
	void Update () {
		BulletTrajectory ();

	}
	
//	//interface member implementation
	public void BulletTrajectory(){
		rigi.velocity = -Vector2.up * speedBulletBlack;
	}
	public BlackBullet(){
		//Debug.Log ("BlackBullet");
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
