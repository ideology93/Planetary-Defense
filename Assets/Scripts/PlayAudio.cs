using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip clip; //make sure you assign an actual clip here in the inspector

    public void Play()
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));

    }
}
