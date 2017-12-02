using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eggGame : MonoBehaviour {
	public Text score;
	public Text lifeCount;

	private int currentScore = 0;
	private int life = 12;

	private Vector3 eggPosition;

	void Start() {
		eggPosition = this.transform.position;
	}
		
	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "score") {
			ScoreUpdate ();
		} else if (col.gameObject.tag == "env") {
			eggDead ();
		}
	}

	private void ScoreUpdate(){
		currentScore++;
		score.text = currentScore.ToString ();
		eggPosition = this.transform.position;
	}

	private void eggDead() {
		life--;
		lifeCount.text = life.ToString ();
		if (life <= 0)
			gameOver ();
		else {
			respawn ();
		}
	}

	private void gameOver() {
		
	}

	private void respawn() {
		this.transform.position = eggPosition;

	}
}
