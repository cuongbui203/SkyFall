using UnityEngine;
using System.Collections;

public class BlueBullet : MonoBehaviour, Bullet, Observer  {
	private Rigidbody2D rigi;
	public float speedBulletBlue ;
	public float damageBulletBlue ;
	// Use this for initialization
	void Start(){
		rigi = GetComponent<Rigidbody2D>();
		GameController.flo.Subscribe (this);
	}
	
	// Update is called once per frame
	void Update () {
		BulletTrajectory ();
	}

	//interface member implementation
	public void BulletTrajectory(){
		rigi.velocity = -Vector2.up * speedBulletBlue;
	}
	public BlueBullet(){
	//	Debug.Log ("BlueBullet");
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
