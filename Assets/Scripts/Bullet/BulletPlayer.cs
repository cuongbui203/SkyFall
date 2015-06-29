using UnityEngine;
using System.Collections;

public class BulletPlayer : MonoBehaviour, Bullet {
	public float speedPlayer;
	public float damagePlayer;

//	public float speed{
//		get{
//			return speedPlayer;
//		}
//		set{
//			speedPlayer = value;
//		}
//	}
//	public float damage{
//		get{
//			return damagePlayer;
//		}
//		set{
//			damagePlayer = value;
//		}
//	}
	// Use this for initialization
	void Start () {
//		damage = damagePlayer;
//		speed = speedPlayer;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		BulletTrajectory ();
	}
	public void BulletTrajectory(){
		rigidbody2D.velocity = Vector2.up * speedPlayer;
	}
}
