using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private GameController gameCont;

	public Text scoreT;
	public Text roomT;
	public Text furnitureT;

	public int score;
	public int room;
	public int furniture;

	void Start () {
		GameObject gameContObj = GameObject.FindGameObjectWithTag ("GameController");
		gameCont = gameContObj.GetComponent<GameController> ();
	}

	void Update () {
		if (gameCont != null) {
			score = gameCont.score;
			room = gameCont.room;
			furniture = gameCont.furniture;
			Destroy (gameCont.gameObject);
		}
		if (scoreT != null)
			scoreT.text = "Score: " + score;
		if (roomT != null)
			roomT.text = "Room of Death: " + room;
		if (furnitureT != null)
			furnitureT.text = "Furniture Destroyed: " + furniture;
	}

	void uiUpdate(){

	}
}
