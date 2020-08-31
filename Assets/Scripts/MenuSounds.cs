using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _playSound;
    [SerializeField] private AudioSource _reverseSound;

    public void PlaySoundStartFrom(float time)
    {
        _playSound.time = time;
        _playSound.Play();
    }

    public void ReverseSoundStartFrom(float time)
    {
        _reverseSound.time = time;
        _reverseSound.Play();
    }

    public void StopPlaySound()
    {
        _playSound.Stop();
    }
}
