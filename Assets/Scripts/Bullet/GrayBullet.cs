using UnityEngine;
using System.Collections;

public class GrayBullet : MonoBehaviour, Bullet, Observer  {
	private Rigidbody2D rigi;
	void Start(){
		rigi = GetComponent<Rigidbody2D>();
		GameController.flo.Subscribe (this);
	}
	public float speedBulletGray ;
	public float damageBulletGray ;
	
	// Update is called once per frame
	void Update () {
		BulletTrajectory ();
	}
	
	//interface member implementation
	public void BulletTrajectory(){
		rigi.velocity = -Vector2.up * speedBulletGray;
	}
	public GrayBullet(){
//		Debug.Log ("GrayBullet");
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
