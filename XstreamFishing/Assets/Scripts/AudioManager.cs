using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    public class AudioManager : MonoBehaviour 
    {
        public AudioSource musicSource;
        public static AudioManager instance = null;

        public AudioSource efxSource;
        public AudioSource p0Source;
        public AudioSource p1Source;
        public AudioSource p2Source;
        public AudioSource p3Source;

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
        
        public void PlaySoundEffect(AudioClip clip, int playerIndex){
            switch (playerIndex){
                case 0:
                    p0Source.clip = clip;
                    p0Source.Play();
                    break;
                case 1:
                    p1Source.clip = clip;
                    p1Source.Play();
                    break;
                case 2:
                    p2Source.clip = clip;
                    p2Source.Play();
                    break;
                case 3:
                    p3Source.clip = clip;
                    p3Source.Play();
                    break;
                default:
                    efxSource.clip = clip;
                    efxSource.PlayOneShot(clip,1.0f);
                    break;

            }
        }
        public void Stop(int playerIndex){
            switch (playerIndex){
                case 0:
                    p0Source.Stop();
                    break;
                case 1:
                    p1Source.Stop();
                    break;
                case 2:
                    p2Source.Stop();
                    break;
                case 3:
                    p3Source.Stop();
                    break;
                default:
                    efxSource.Stop();
                    break;

            }
        }

    }