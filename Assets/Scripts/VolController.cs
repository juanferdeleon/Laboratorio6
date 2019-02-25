using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolController : MonoBehaviour
{
    private AudioSource audioSource;

    private float musicVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVol;
    }

    public void setVol(float vol) {
        musicVol = vol;
    }

}
