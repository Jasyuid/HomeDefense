using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GameController gameCont;

	Animator anim;
	Rigidbody2D rbody;

	private float speed = 100.0f;
	public float shotdelay;
	private float rot;

	int contents = 5;
	private int health = 5;
	private float recoverT = 2;

	public GameObject book, glass, dish, remote, vase;
	public GameObject[] projs = new GameObject[5];

	void Start () {
		GameObject gameContObj = GameObject.FindGameObjectWithTag ("GameController");
		gameCont = gameContObj.GetComponent<GameController> ();

		rbody = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		projs [0] = book;
		projs [1] = glass;
		projs [2] = dish;
		projs [3] = remote;
		projs [4] = vase;

		rot = 180;
	}

	void Update () {
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);


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

		if (contents > 0) {
			if (Input.GetKeyDown ("k")) {
				GameObject proj = projs[Random.Range(0, 4)];
				Vector3 posi = proj.transform.position;
				posi = gameObject.transform.position;
				proj.transform.position = posi;
				Vector3 roti = proj.transform.eulerAngles;
				roti.z = rot; 
				proj.transform.eulerAngles = roti;
				Instantiate(proj);
				contents--;
				SoundEffects.Instance.throwSound();
			}
			
		}

		if (recoverT < 2) {
			recoverT += 1 * Time.deltaTime;
			gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
		} else {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}

		if (health > 5)
			health = 5;
		if (health < 0)
			health = 0;

		gameCont.health = health;
		gameCont.projs = contents;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Item"){
			SoundEffects.Instance.switchSound();
			contents++;
			gameCont.score += 10;
			Destroy(other.gameObject);
		}

		if (other.gameObject.name == "HealthGenerator") {
			SoundEffects.Instance.lifeSound();
			health++;
			Destroy(other.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (Input.GetKey ("l")) {
			if(other.gameObject.tag == "Box"){
				other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				SoundEffects.Instance.destroySound();
				contents++;
				gameCont.furniture++;
				gameCont.score -= 5;
				other.enabled = false;
			}

			if(other.gameObject.tag == "Box2"){
				other.gameObject.GetComponent<SpriteRenderer>().enabled = true;	
				SoundEffects.Instance.destroySound();
				contents+=3;;
				gameCont.furniture++;
				gameCont.score -= 15;
				other.enabled = false;
			}		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "EnemyProj") {
			if(recoverT >= 2){
				SoundEffects.Instance.hitSound();
				health--;
				recoverT = 0;
			}
		}

	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
			if(recoverT >= 2){
				SoundEffects.Instance.hitSound();
				health--;
				recoverT = 0;
			}
		}

	}
}
