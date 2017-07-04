using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private GameController gameCont;

	Animator anim;
	Rigidbody2D rbody;
	public float speed = 30.0f;
	private float rot;

	private GameObject player;
	private Vector2 target;

	public GameObject bullet;
	private float shotDelay;

	void Start () {
		GameObject gameContObj = GameObject.FindGameObjectWithTag ("GameController");
		gameCont = gameContObj.GetComponent<GameController> ();

		rbody = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		player = GameObject.FindGameObjectWithTag ("Player");

		shotDelay = 0.0f;
	}

	void Update () {
		float xd = gameObject.transform.position.x - player.transform.position.x;
		float yd = gameObject.transform.position.y - player.transform.position.y;
		if ((Mathf.Sqrt ((xd * xd) + (yd * yd))) > 120) {
			xd = 0;
			yd = 0;
		}

		if (xd >= 0.2 && yd >= 0.2) {
			if(xd < yd) rot = 180;
			if(xd > yd) rot = 90;
		}
		if (xd <= -0.2 && yd <= -0.2) {
			if(xd > yd) rot = 270;
			if(xd < yd) rot = 0;
		}
		if (xd >= 0.2 && yd <= -0.2) {
			if(xd < Mathf.Abs(yd)) rot = 0;
			if(xd > Mathf.Abs(yd)) rot = 90;
		}
		if (xd <= -0.2 && yd >= 0.2) {
			if(Mathf.Abs(xd) < yd) rot = 180;
			if(Mathf.Abs(xd) > yd) rot = 270;
		}
		if (xd < 0.2 && xd > -0.2) {
			if(yd > 0) rot = 180;
			if(yd < 0) rot = 0;
		}
		if (yd < 0.2 && yd > -0.2) {
			if(xd > 0) rot = 90;
			if(xd < 0) rot = 270;
		}

		if (xd > 0.2)
			xd = -1;
		else if (xd < -0.2)
			xd = 1;
		else
			xd = 0;

		if (yd > 0.2)
			yd = -1;
		else if (yd < -0.2)
			yd = 1;
		else
			yd = 0;

		Vector2 movement_vector = new Vector2 (xd * speed, yd * speed);

		if (movement_vector == Vector2.zero) {
			anim.SetBool("walking", false);
		} else {
			anim.SetBool("walking", true);
			anim.SetFloat("input_x", movement_vector.x);
			anim.SetFloat("input_y", movement_vector.y);
			
			/*if (movement_vector.y < 0)
				rot = 180;
			else if (movement_vector.y > 0)
				rot = 0;
			else if (movement_vector.x < 0)
				rot = 90;
			else if (movement_vector.x > 0)
				rot = 270;*/


		}
	
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);
		if (shotDelay > 0.0f) {
			shotDelay -= Time.deltaTime;
		}
		if (shotDelay <= 0.0f) {
			if (xd != 0 || yd != 0) {
				Vector3 posi = bullet.transform.position;
				posi = gameObject.transform.position;
				bullet.transform.position = posi;
				Vector3 roti = bullet.transform.eulerAngles;
				roti.z = rot; 
				bullet.transform.eulerAngles = roti;
				Instantiate (bullet);
				shotDelay = 1.0f;
				SoundEffects.Instance.shootSound();
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag == "Proj"){
			gameCont.score += 20;
			Destroy(gameObject);
		}
	} 
}
