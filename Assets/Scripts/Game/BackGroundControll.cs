using UnityEngine;
using System.Collections;

public class BackGroundControll : MonoBehaviour {
	public float speed;
	public Transform centerPos;
	public Transform endPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		rigidbody2D.velocity = -Vector2.up * speed;
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name.Equals("Wall")){
			transform.position = new Vector3( 0.0007770061f, transform.position.y + 4.17f * (-endPos.position.y + centerPos.position.y), 0);
		}
	}
}
