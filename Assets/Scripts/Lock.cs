using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lock : MonoBehaviour {

	//public GameObject[] kills;
	public List<GameObject> kills;

	void Start () {
	
	}

	void Update () {
		for (int i = 0; i < kills.Count; i++) {
			if(kills[i] == null)
				kills.Remove(kills[i]);
		}

		if (kills.Count == 0) {
			Destroy(gameObject);
		}
	}
}
