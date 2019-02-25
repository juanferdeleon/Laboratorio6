using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, die, powerUp, kill;

    public static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        die = Resources.Load<AudioClip>("die");
        powerUp = Resources.Load<AudioClip>("powerUp");
        kill = Resources.Load<AudioClip>("haha");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "jump":
                audioSource.PlayOneShot(jump);
                break;
            case "die":
                audioSource.PlayOneShot(die);
                break;
            case "powerUp":
                audioSource.PlayOneShot(powerUp);
                break;
            case "kill":
                audioSource.PlayOneShot(kill);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
