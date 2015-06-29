using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Schedule(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll){
		Destroy (coll.gameObject);
	}
	public IEnumerator Schedule(float time){
		yield return new WaitForSeconds(time);
		if(gameObject != null){
			gameObject.SetActive (false);
		}

	}
}
