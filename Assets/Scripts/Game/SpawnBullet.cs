using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnBullet : MonoBehaviour {
	public List<GameObject> listBullet;
	public float fireRate;
	FactoryBullet factoryBullet;
	public Transform posBullet;
	// Use this for initialization
	void Start () {
		factoryBullet = new FactoryBullet ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator SpawnFly(){
		while(true){
			int bulletRandom;
			bulletRandom = Random.Range(0, listBullet.Count-1);
			factoryBullet.InstantiateBullet(listBullet[bulletRandom].name, posBullet.position);
			yield return new WaitForSeconds (fireRate);
		}
		
	}
}
