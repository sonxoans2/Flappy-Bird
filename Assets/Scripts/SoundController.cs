using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    public AudioClip hit, point, swooshing, wing;
    AudioSource audio;

    void Start () {
        audio = GetComponent<AudioSource> ();
        audio.rolloffMode = AudioRolloffMode.Linear;
        audio.volume = 1;
    }

    // Update is called once per frame
    void Update () {
    }
    void PlaySound (AudioClip audioClip) {
        //if(GameController.instance.isSound == 1) {
            audio.PlayOneShot (audioClip);
        //}
    }
    public void SoundHit(){
        PlaySound (hit);
    }

    public void SoundPoint() {
        PlaySound (point);
    }

    public void SoundSwooshing () {
        PlaySound (swooshing);
    }

    public void SoundWing () {
        PlaySound (wing);
    }
}
