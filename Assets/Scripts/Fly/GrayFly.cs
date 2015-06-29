using UnityEngine;
using System.Collections;

public class GrayFly : AIFly{

	public float hpFlyGray;
	public float damageFlyGray;
	public float speedFlyGray;
	private Rigidbody2D rigi;
	public Vector3 posBullet;
	public GameObject prefabBullet;
	void Start(){
		rigi = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		RightLeft (rigi, speedFlyGray);
	}
	public GrayFly(){
		Debug.Log ("Red Fly");
	}
}
