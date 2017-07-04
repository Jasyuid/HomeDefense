using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	public static SoundEffects Instance;

	public AudioClip shoot;
	public AudioClip throwProj;
	public AudioClip lifeUp;
	public AudioClip destroy;
	public AudioClip switchS;
	public AudioClip hit;

	void Awake(){
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	public void shootSound(){
		AudioSource.PlayClipAtPoint(shoot, transform.position, 0.3f);
	}

	public void throwSound(){
		MakeSound (throwProj);
	}

	public void lifeSound(){
		MakeSound (lifeUp);
	}

	public void destroySound(){
		MakeSound (destroy);
	}

	public void switchSound(){
		MakeSound (switchS);
	}

	public void hitSound(){
		MakeSound (hit);
	}

	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
