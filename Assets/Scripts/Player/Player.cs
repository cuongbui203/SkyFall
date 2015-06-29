using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	private float Xmax, Xmin, Ymin, Ymax; // lấy các giá trị max, min cho camer
	private Vector3 screenPoint, offset, st;
	private bool clicked = false;
	public Transform posBullet;
	public GameObject prefabBullet;
	public float fireRate;
	public GameObject explosion;
	public UISlider uISliderHealth;
	public AudioClip adc;
	public GameObject[] listLives;
	public GameObject CircleSafe;
	public GameObject effect;

	public float hp;
	public int lives;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		hp = 100;
		st = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Xmax = st.x;
		// khi camera ko ở vị trí gốc tọa độ nữa ta phải thay đổi cách tính Xmax và Ymax
		Xmin = -Xmax + 2 * Camera.main.transform.position.x;
		Ymax = st.y;
		Ymin = -Ymax + 2 * Camera.main.transform.position.y;
		StartCoroutine (Shoot (fireRate));

	}
	
	// Update is called once per frame
	void Update () {
		uISliderHealth.value = hp / 100;
		if(GameStateManager.GameState == GameState.Playing){
			PlayerController ();
			if(effect.activeSelf){
				GameController.flo.NotifyObserver ();
				Handheld.Vibrate();
			}
		}

	}
	void PlayerController(){
		if(hp <= 0 && gameObject.activeSelf && lives > 0){


			Instantiate(explosion, transform.position, Quaternion.identity);
			lives -= 1;
			listLives[lives].SetActive(false);
			PlayerStateManager.PlayerState = PlayerState.Die;
			gameObject.SetActive(false);
		}
		if(lives == 0){
			Instantiate(explosion, transform.position, Quaternion.identity);
			lives = -1;
			GameStateManager.GameState = GameState.Endgame;
			PlayerStateManager.PlayerState = PlayerState.Die;
			gameObject.SetActive(false);
		}
	}
	void LimitMove (float limX, float limY)
	{ 
		Vector3 playerSize = renderer.bounds.size;	
		if (limX <= (Xmin + playerSize.x / 2)) {
			//			Debug.Log("qua trái");
			transform.position = new Vector3 (Xmin + playerSize.x / 2, transform.position.y, transform.position.z);
		}
		if (limX >= Xmax - playerSize.x / 2) {
			transform.position = new Vector3 (Xmax - playerSize.x / 2, transform.position.y, transform.position.z);
		}
		// 
		if (limY <= Ymin + playerSize.y / 2) {
			transform.position = new Vector3 (transform.position.x, Ymin + playerSize.y / 2, transform.position.z);
		}
		if (limY >= Ymax - playerSize.y / 2) {
			transform.position = new Vector3 (transform.position.x, Ymax - playerSize.y / 2, transform.position.z);
		}
	}

	void OnMouseDown ()
	{
//		clicked = true;
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));

	}
	
	void OnMouseDrag ()
	{
//		Vector3 newScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y + 10, 0);
//		// Adjust the location by adding an offset.
//		Vector3 newPosition = Camera.main.ScreenToWorldPoint (newScreenPoint) + offset;
//		// Assign new position.
//		if (clicked) {
//			transform.position = newPosition;
//		}
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPos = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		transform.position = currentPos;
		LimitMove (transform.position.x, transform.position.y);
	}
	void Move(){

	}
	IEnumerator Shoot(float time){
		yield return new WaitForSeconds (2f);
		while (true) {
			Instantiate (prefabBullet, posBullet.position, Quaternion.identity);
			yield return new WaitForSeconds (time);
		}


	}

	void OnTriggerEnter2D(Collider2D coll){
		float damageEnemy = 0;
		if(coll.gameObject.GetComponent<InfoBullet>() != null){
			damageEnemy = coll.gameObject.GetComponent<InfoBullet>().getDamage();
			Destroy(coll.gameObject);
		}

		if(coll.gameObject.GetComponent<InfoFly>() != null){
			damageEnemy = coll.gameObject.GetComponent<InfoFly>().getDamage();
			coll.gameObject.GetComponent<InfoFly>().SetHp(-100);
		}
		if(coll.gameObject.name == "itemEffect(Clone)"){
			Destroy(coll.gameObject);
			StartCoroutine(Effect());
		}
		if(damageEnemy != 0 && !CircleSafe.activeSelf){
			hp -= damageEnemy;
		}
	}
	public void ReSetHp(){
		StartCoroutine (Shoot (fireRate));
		hp = 100;
	}
	public float GetHp(){
		return hp;
	}
	IEnumerator Effect(){
		effect.SetActive (true);

		yield return new WaitForSeconds (2);
		effect.SetActive (false);
	}
}
