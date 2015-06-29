using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject prefabRedFly;
	public GameObject prefabBlueFly;
	public GameObject prefabBlackFly;
	public GameObject teamCircle;
	Vector3 edgeCamera;
	//public Transform 
	public int numberFlyInWave;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	FactoryFly factoryFly = new FactoryFly();

	// Use this for initialization
	void Start () {
		edgeCamera = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		StartCoroutine (SpawnFly());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator SpawnFly(){
		yield return new WaitForSeconds (2);
		while(true){
			for(int i = 0; i < numberFlyInWave; i++){
				Vector3 newPos = new Vector3(Random.Range( -edgeCamera.x , edgeCamera.x), edgeCamera.y, -1);
				int flyRandom;
				flyRandom = Random.Range(1, 4);
				switch(flyRandom){
				case 1:
					factoryFly.InstantiateFly ("BlackFly", newPos);
					yield return new WaitForSeconds (spawnWait);
					break;
				case 2:
					factoryFly.InstantiateFly ("BlueFly", newPos);
					yield return new WaitForSeconds (spawnWait);
					break;
				
				case 3:
					factoryFly.InstantiateFly ("RedFly", newPos);
					yield return new WaitForSeconds (spawnWait);
					break;
				}
			}
			yield return new WaitForSeconds (waveWait);
		}

		}
}
