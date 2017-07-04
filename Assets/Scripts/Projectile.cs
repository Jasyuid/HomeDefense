using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	Rigidbody2D rbody;

	private Vector2 move = new Vector2(0, 0);
	public float speed = 200.0f;

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		Vector3 rot = gameObject.transform.eulerAngles;
		if (rot.z == 0)
			move = new Vector2 (0, 1);
		else if(rot.z >= 45 && rot.z <= 135)
			move = new Vector2 (-1, 0);
		else if(rot.z >= 135 && rot.z <= 225)
			move = new Vector2 (0, -1);
		else if(rot.z >= 225 && rot.z <= 305)
			move = new Vector2 (1, 0);
	}

	void Update () {
		Vector2 movement_vector = new Vector2(move.x * speed, move.y * speed);
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

		Vector3 roti = gameObject.transform.eulerAngles;
		roti.z += 360 * Time.deltaTime;
		gameObject.transform.eulerAngles = roti;
	}

	void OnCollisionEnter2D (Collision2D other){
		Destroy (gameObject);
	}
}
