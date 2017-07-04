using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public GameObject[] items = new GameObject[5];
	private GameObject last;

	private float rate;

	void Start () {
		
	}

	void Update () {
		if (rate <= 0) {
			GameObject obj = items[Random.Range(0, 4)];
			Vector3 posi = obj.transform.position;
			posi = gameObject.transform.position;
			obj.transform.position = posi;
			last = Instantiate(obj);
			rate = Random.Range (5, 10);
		}

		if(last == null) 
			rate -= Time.deltaTime;
	}
}
