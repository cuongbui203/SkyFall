using UnityEngine;
using System.Collections;

public class OrangeFly : AIFly{

	public float hpFlyOrange;
	public float damageFlyOrange;
	public float speedFlyOrange;
	private Rigidbody2D rigi;
	public Vector3 posBullet;
	public GameObject prefabBullet;
	void Start(){
		rigi = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		UpDown (rigi, speedFlyOrange);
	}
	public OrangeFly(){
		Debug.Log ("Red Fly");
	}
}
