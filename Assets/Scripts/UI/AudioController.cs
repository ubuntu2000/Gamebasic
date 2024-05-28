using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GameBasic
{

    public class AudioController : MonoBehaviour
    {
        [Header("Main Setting: ")]
        [Range(0f, 1f)]
        public float musicVol = 0.3f;
        [Range(0f, 1f)]
        public float SfxVol = 1f;

        public AudioSource musicAus;
        public AudioSource SfxAus;

        [Header("Music and Sound in GamePlay: ")]
        public AudioClip playerAtk;
        public AudioClip enemyDead;
        public AudioClip gameOver;
        public AudioClip[] bgms;

        private void Start()
        {
            if (musicAus == null || SfxAus == null) return;
            musicVol = Pref.musVol;
            SfxVol = Pref.sfxVol;

            musicAus.volume = musicVol;
            SfxAus.volume = SfxVol;
        }



        public void PlaySound(AudioClip [] sounds, AudioSource aus = null ) 
            /* PlaySound truyen 1 mang am thanh nhung ko truyen vao audio dieu khien (audioSound)
             * thi cau lenh nay lay audioSound cua lop audioController, neu chung ta co audioSound o 1 noi nao do trong game
             * thi cau lenh se lay audioSound truyen vao cua chung ta chu ko lay audioSound cua class AudioController
             */
        {

            if (!aus)
                aus = SfxAus;

           

            if (sounds == null || sounds.Length <= 0 || aus == null) return;

            int randIdx = Random.Range(0, sounds.Length);
            if (sounds[randIdx])
                aus.PlayOneShot(sounds[randIdx]);
        }
        public void PlaySound(AudioClip sound, AudioSource aus = null)
        {
            if (!aus)
                aus = SfxAus;
            if (sound)
                aus.PlayOneShot(sound,SfxVol);
        }

        public  void PlayMusic(AudioClip [] musics, bool isLoop = true)
        {
            if (musicAus == null || musics == null || musics.Length <= 0) return;

            int randIdx = Random.Range(0, musics.Length);

            if(musics[randIdx])
            {
                // musicAus.clip la Audioclip o AudioSound
                musicAus.clip = musics[randIdx];
                musicAus.loop = isLoop;
                musicAus.volume = musicVol;
                musicAus.Play();
            }
        }
        
        public void PlayMusic(AudioClip music, bool isLoop = true)
        {
            if (musicAus == null || music == null ) return;

            musicAus.clip = music;
            musicAus.loop = isLoop;
            musicAus.volume = musicVol;
            musicAus.Play();
        }

        public void SetMusicVolume( float vol)
        {
            if (musicAus == null) return;

            musicAus.volume = vol;
        }
        public void StopMusic()
        {
            if (musicAus == null) return;

            musicAus.Stop();
        }

        public void PlayBgm()
        {
            PlayMusic(bgms);
        }
    }
}