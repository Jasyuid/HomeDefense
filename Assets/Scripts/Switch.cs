using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour {

	private GameController gameCont;
	public List<GameObject> active;

	void Start(){
		GameObject gameContObj = GameObject.FindGameObjectWithTag ("GameController");
		gameCont = gameContObj.GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			for(int i = 0; i < active.Count; i++){
				active[i].SetActive(true);
			}
			gameCont.room++;
			Destroy (gameObject);
		}
	}
}
