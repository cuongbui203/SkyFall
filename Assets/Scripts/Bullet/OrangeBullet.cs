using UnityEngine;
using System.Collections;

public class OrangeBullet : MonoBehaviour, Bullet, Observer  {

	public float speedBulletOrange ;
	public float damageBulletOrange;
	private Rigidbody2D rigi;
	void Start(){
//		damage = damageBulletOrange;
//		speed = speedBulletOrange;
		GameController.flo.Subscribe (this);
		rigi = GetComponent<Rigidbody2D>();
	}
//	public float speed{
//		get{
//			return speedBulletOrange;
//		}
//		set{
//			speedBulletOrange = value;
//		}
//	}
//	public float damage{
//		get{
//			return damageBulletOrange;
//		}
//		set{
//			damageBulletOrange = value;
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		BulletTrajectory ();
	}
	
	//interface member implementation
	public void BulletTrajectory(){
		rigi.velocity = -Vector2.up * speedBulletOrange;
	}
	public OrangeBullet(){
		//Debug.Log ("OrangeBullet");
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
