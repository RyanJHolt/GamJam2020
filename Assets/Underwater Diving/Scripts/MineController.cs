using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {

	public GameObject explosionAnim;
    public AudioSource AudioData;
    private AudioClip explosionSoundFile;

	// Use this for initialization
	void Start () {
        AudioData = GetComponent<AudioSource>();
        explosionSoundFile = AudioData.clip;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
            AudioData.PlayOneShot(explosionSoundFile, 1.0f);
			Destroy(gameObject);
			Instantiate(explosionAnim, transform.position, Quaternion.identity);
		}	
	}
}
