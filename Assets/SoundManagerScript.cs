using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDashSound, deathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
       playerDashSound = Sounds.MainSounds.Load<AudioClip>("Dash");
       deathSound = Sounds.MainSounds.Load<AudioClip>("Die");

        audioSrc = GetComponent<AurioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Dash":
                audioSrc.PlayOneShot(playerDashSound);
                break;
            case "Die":
                audioSrc.PlayOneShot(deathSound);
                break;
            

        }
    }
}
