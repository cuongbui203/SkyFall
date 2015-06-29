using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static int score { 
		get; 
		set;
	}
	void Start(){
		score = 0;
	}

}
