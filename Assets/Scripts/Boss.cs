using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	private GameController gameCont;
	public GameObject trigger;
	
	Animator anim;
	Rigidbody2D rbody;
	private float speed = 80.0f;
	private float rot;
	private int dir = 1;

	private int health = 20;

	public GameObject bullet;
	private float shotDelay;
	private float shotDelay2;

	private float hit;

	public GameObject bh;
	public GameObject bh1;
	public GameObject bh2;

	void Start () {
		GameObject gameContObj = GameObject.FindGameObjectWithTag ("GameController");
		gameCont = gameContObj.GetComponent<GameController> ();

		bh.SetActive (true);
		bh1.SetActive (true);
		bh2.SetActive (true);

		rbody = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		shotDelay = 0.0f;
		hit = 0.0f;
	}

	void Update () {
		if (gameObject.transform.position.x < -105)
			dir = 1;
		if (gameObject.transform.position.x > 125)
			dir = -1;
		Vector2 movement_vector = new Vector2 (speed*dir, 0);
		
		if (movement_vector == Vector2.zero) {
			anim.SetBool("walking", false);
		} else {
			anim.SetBool("walking", true);
			anim.SetFloat("input_x", movement_vector.x);
			anim.SetFloat("input_y", movement_vector.y);
			
			if (movement_vector.y < 0)
				rot = 180;
			else if (movement_vector.y > 0)
				rot = 0;
			else if (movement_vector.x < 0)
				rot = 90;
			else if (movement_vector.x > 0)
				rot = 270;
		}
		
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

		if (shotDelay > 0.0f) {
			shotDelay -= Time.deltaTime;
		}
		if (shotDelay2 > 0.0f) {
			shotDelay2 -= Time.deltaTime;
		}
		if (shotDelay <= 0.0f) {
			Vector3 posi = bullet.transform.position;
			posi = gameObject.transform.position;
			bullet.transform.position = posi;
			Vector3 roti = bullet.transform.eulerAngles;
			roti.z = 180; 
			bullet.transform.eulerAngles = roti;
			Instantiate (bullet);
			shotDelay = 0.1f;
			SoundEffects.Instance.shootSound();
		}

		if (shotDelay2 <= 0.0f) {
			Vector3 posi = bullet.transform.position;
			posi = gameObject.transform.position;
			bullet.transform.position = posi;
			Vector3 roti = bullet.transform.eulerAngles;
			roti.z = 90; 
			bullet.transform.eulerAngles = roti;
			Instantiate (bullet);
			roti = bullet.transform.eulerAngles;
			roti.z = 270; 
			bullet.transform.eulerAngles = roti;
			Instantiate (bullet);
			shotDelay2 = 1.0f;
			SoundEffects.Instance.shootSound();
		}

		if (hit > 0.0f) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			hit -= Time.deltaTime;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}

		gameCont.bosshealth = health;

		Vector3 poib = bh.GetComponent<RectTransform>().localScale;
		poib = new Vector3 ((float)health/20.0f, 1, 1);
		bh.GetComponent<RectTransform> ().localScale = poib;

		if (health <= 0) {
			gameCont.score += 100;
			gameCont.win = true;
			Destroy(gameObject);
		}

	}

	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag == "Proj"){
			gameCont.score += 10;
			health--;
			hit = 0.1f;
		}
	}
}
