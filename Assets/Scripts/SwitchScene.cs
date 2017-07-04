using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {
	
	public string LevelName;
	
	void Awake () {
		if (LevelName == "level") {
			Destroy (GameObject.Find("level_menu"));
			Destroy (GameObject.Find("level_menu 1"));
		}
		Application.LoadLevel(LevelName);
	}
}
