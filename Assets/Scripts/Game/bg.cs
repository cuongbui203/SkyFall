using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bg : MonoBehaviour {
	public float speed;
	public List<Material> materials;
	float pos;
	// Use this for initialization
	void Start () {
		//StartCoroutine (test());
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed;
		if(pos > 1){
			pos -= 1;
		}
		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, pos);
	}
	IEnumerator test(){
		while(true){
			int x;
			x = Random.Range (0, materials.Count);
			Debug.Log(x);
			GetComponent<Renderer> ().material = materials[x];
			yield return new WaitForSeconds(2);
		}
	}
}
