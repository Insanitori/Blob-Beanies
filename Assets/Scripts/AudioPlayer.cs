using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip ploping;
    public float volume = 0.5f;

    public bool po;
    // Start is called before the first frame update
    void Start()
    {
        po = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(po && !audioSource.isPlaying)
        {
            audioSource.Play();
            po = false;
        }
    }
}
