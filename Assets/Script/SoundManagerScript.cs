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
    //    playerDashSound = Assets.Sounds.MainSounds.Load<AudioClip>("Dash");
    //playerDashSound = GetComponent<AudioSource>("Dash");
    //    deathSound = Sounds.MainSounds.Load<AudioClip>("Die");

        //audioSrc = GetComponent<AudioSource>("Die");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public static void PlaySound(string clip)
    // {
    //     switch (clip)
    //     {
    //         case "Dash":
    //             audioSrc.PlayOneShot(playerDashSound);
    //             break;
    //         case "Die":
    //             audioSrc.PlayOneShot(deathSound);
    //             break;
            

    //     }
    // }
}
