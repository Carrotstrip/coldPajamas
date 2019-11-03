using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    public class AudioManager : MonoBehaviour 
    {
        public AudioSource efxSource;
        public AudioSource musicSource;
        public static AudioManager instance = null;


        void Awake ()
        {
            // Check if there is already an instance of SoundManager
            if (instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
                // Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy (gameObject);

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad (gameObject);
        }


        // Play a single clip through the sound effects source.
        public void Play(AudioClip clip)
        {
            efxSource.clip = clip;
            efxSource.Play();
        }

        // Play a single clip through the music source.
        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

    }