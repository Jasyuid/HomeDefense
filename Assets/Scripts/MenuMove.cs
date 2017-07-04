using UnityEngine;
using System.Collections;

public class MenuMove : MonoBehaviour {

	private float speed = -10.0f;

	void Awake(){
		if (gameObject.name == "level_menu") {
			if(GameObject.FindGameObjectWithTag("B1") != null){
				Destroy(gameObject);
			}
			gameObject.tag = "B1";
		} else {
			if(GameObject.FindGameObjectWithTag("B2") != null){
				Destroy(gameObject);
			}
			gameObject.tag = "B2";
		}

	}

	void Update () {
		Vector3 pos = gameObject.transform.position;
		
		pos.x += speed * Time.deltaTime;
		
		if (pos.x < -1110) {
			pos.x = 810;
		}
		
		gameObject.transform.position = pos;
	}
}
