using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public GameObject startGame;
	public GameObject endGame;
	public GameObject itemEffect;
	public Transform posItemEffect;
	public UILabel labelScore;
	public UILabel labelScoreEndGame;
	public UILabel labelRevival;
	public static FlyObject flo;
	private Vector3 startPosition;
	private bool isPlayerDie;
	public static bool isRestart;	
	private int highScore;
	private int scoreEffect;
	// Use this for initialization
	void Start () {
		GameStateManager.GameState = GameState.Playing;
		PlayerStateManager.PlayerState = PlayerState.Fly;
		highScore = PlayerPrefs.GetInt ("best");
		isPlayerDie = false;
		startPosition = player.transform.position;
		if(!isRestart){
			flo = new FlyObject();
			startGame.SetActive (true);
			Time.timeScale = 0;
		}
		scoreEffect = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameStateManager.GameState == GameState.Playing) {
			labelScore.text = ScoreManager.score + "";
			if(ScoreManager.score == scoreEffect){
				scoreEffect *= 2;
				GameObject go = Instantiate(itemEffect, posItemEffect.position, Quaternion.identity) as GameObject;
			}
			PlayerController ();
		} else if(!endGame.activeSelf){
			if(ScoreManager.score > highScore){
				highScore = ScoreManager.score;
				PlayerPrefs.SetInt ("best", highScore);
			}
			labelScoreEndGame.text = "Score: " + ScoreManager.score + "\nBest: " + highScore;
			endGame.SetActive(true);
		}
	}
	void PlayerController(){
		if(PlayerStateManager.PlayerState == PlayerState.Die && !isPlayerDie){
			isPlayerDie = true;
			StartCoroutine(DelayRevival(2, player));
		}

	}
	IEnumerator DelayRevival(float time, GameObject goPlayer){
		labelRevival.gameObject.SetActive (true);
		for(float i = time; i >= 1; i--){
			labelRevival.text = "revival in: \n" + i + "";
			yield return new WaitForSeconds (1);
		}
		//yield return new WaitForSeconds (time);
		if(player != null && GameStateManager.GameState == GameState.Playing){
			labelRevival.gameObject.SetActive (false);
			player.SetActive (true);
			isPlayerDie = false;
			player.transform.position = startPosition;
			player.GetComponent<Player>().ReSetHp ();
			player.GetComponent<Player>().CircleSafe.SetActive(true);
			StartCoroutine(player.GetComponent<Player>().CircleSafe.GetComponent<Circle>().Schedule(2));
			PlayerStateManager.PlayerState = PlayerState.Fly;
		}
	}
	public void StartGame(){
		startGame.SetActive (false);
		Time.timeScale = 1;
	}
	public void RestartGame(){
		isRestart = true;
		ScoreManager.score = 0;
		endGame.SetActive (false);
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
//	void OnGUI() {
//		if (GUI.Button(new Rect(0, 10, 100, 32), "Vibrate!"))
//			Handheld.Vibrate();
//	}
}
