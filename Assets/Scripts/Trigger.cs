using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	
	public bool on;

	void OnTriggerStay2D(Collider2D other){
		on = true;
	}

	void OnTriggerExit2D(Collider2D other){
		on = false;	
	}
}
