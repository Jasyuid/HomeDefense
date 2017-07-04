using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private Text scoreText;
	private Text projText;
	private Text roomText;

	private Image h1, h2, h3, h4, h5;
	public Sprite hel, hele;

	public int score;
	public int room;
	public int projs;
	public int health;
	public int furniture;

	public int bosshealth;

	public bool win;

	void Awake () {
		health = 5;
	}

	void Update () {
		if (Application.loadedLevelName == "level") {
			scoreText = GameObject.FindGameObjectWithTag ("UI_Score").GetComponent<Text> ();
			projText = GameObject.FindGameObjectWithTag ("UI_Proj").GetComponent<Text> ();
			roomText = GameObject.FindGameObjectWithTag ("UI_Room").GetComponent<Text> ();
			h1 = GameObject.FindGameObjectWithTag ("UI_h1").GetComponent<Image> ();
			h2 = GameObject.FindGameObjectWithTag ("UI_h2").GetComponent<Image> ();
			h3 = GameObject.FindGameObjectWithTag ("UI_h3").GetComponent<Image> ();
			h4 = GameObject.FindGameObjectWithTag ("UI_h4").GetComponent<Image> ();
			h5 = GameObject.FindGameObjectWithTag ("UI_h5").GetComponent<Image> ();

			if (scoreText != null)
				uiUpdate ();
			if (h1 != null)
				healthUpdate ();
			if (bosshealth != null)
				bhealthUpdate ();

			if (health <= 0)
				Application.LoadLevel ("gameover");
			if (win)
				Application.LoadLevel ("win");
		}


	}

	void uiUpdate(){
		scoreText.text = "Score: " + score;
		projText.text = "Projectiles: " + projs;
		roomText.text = "Room: " + room;
	}

	void healthUpdate(){
		if (health == 5) {
			h1.sprite = hel;
			h2.sprite = hel;
			h3.sprite = hel;
			h4.sprite = hel;
			h5.sprite = hel;
		} else if (health == 4) {
			h1.sprite = hel;
			h2.sprite = hel;
			h3.sprite = hel;
			h4.sprite = hel;
			h5.sprite = hele;
		} else if (health == 3) {
			h5.sprite = hele;
			h4.sprite = hele;
			h1.sprite = hel;
			h2.sprite = hel;
			h3.sprite = hel;
		} else if (health == 2) {
			h5.sprite = hele;
			h4.sprite = hele;
			h3.sprite = hele;
			h1.sprite = hel;
			h2.sprite = hel;
		} else if (health == 1) {
			h5.sprite = hele;
			h4.sprite = hele;
			h3.sprite = hele;
			h2.sprite = hele;
			h1.sprite = hel;
		} else if (health == 0) {
			h5.sprite = hele;
			h4.sprite = hele;
			h3.sprite = hele;
			h2.sprite = hele;
			h1.sprite = hele;
		}
	}

	void bhealthUpdate(){
		print (bosshealth);
	}
}
