using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource pressed;

    public void PlayPressed()
    {
        pressed.Play();
    }
}
