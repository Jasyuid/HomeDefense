using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
		if (gameObject.GetComponent<SpriteRenderer> ().enabled) {
			//gameObject.transform.GetChild(0).position = gameObject.transform.position;
			Transform trans = gameObject.transform.FindChild("Smash");
			GameObject obj = trans.gameObject;
			obj.SetActive(true);
		}
	}
}
