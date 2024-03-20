using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aviator
{
    [Serializable]
    class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<Sound> sounds = new();
        [SerializeField] private AudioSource bgSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip[] bgClips;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            bgSource.volume = 0.4f;
            sfxSource.volume = 0.4f;
        }

        private void UpdateVolume(float volume)
        {

        }

        public void PlayMusic()
        {
            bgSource.loop = true;
            bgSource.playOnAwake = true;
            bgSource.clip = bgClips[0];
            bgSource.Play();
        }

        public void PlaySFX(string name)
        {
            Sound sound = sounds.Find(s => s.name == name);

            if (sound != null && sound.clip)
            {
                sfxSource.PlayOneShot(sound.clip);
            }
        }
    }
}