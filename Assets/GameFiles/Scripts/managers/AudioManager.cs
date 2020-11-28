using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class AudioManager : MonoBehaviour
    {
        [Serializable]
        public class Sound
        {
            public string Name;
            public AudioClip Clip;
            [Range(0f, 1f)] public float Volume;
            [Range(0f, 1f)] public float Pitch;
            public bool Loop;
            [HideInInspector] public AudioSource Source;
        }

        public static AudioManager Instance;

        public List<Sound> Sounds = new List<Sound>();

        private Dictionary<string, Sound> _soundsDict = new Dictionary<string, Sound>();

        private void Awake()
        {
            Init();
            foreach (var sound in Sounds)
            {
                sound.Source = gameObject.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
                sound.Source.loop = sound.Loop;
                _soundsDict[sound.Name] = sound;
            }
        }

        private void Init()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlayIfNotPlaying(string audioTrackName)
        {
            var sound = GetFromAudioTrackName(audioTrackName);
            if (sound != null && !sound.Source.isPlaying)
            {
                sound.Source.Play();
            }
        }

        public void Play(string audioTrackName)
        {
            var sound = GetFromAudioTrackName(audioTrackName);
            sound?.Source.Play();
        }

        public void Stop(string audioTrackName)
        {
            var sound = GetFromAudioTrackName(audioTrackName);
            sound?.Source.Stop();
        }

        private Sound GetFromAudioTrackName(string audioTrackName)
        {
            var sound = _soundsDict[audioTrackName];
            if (sound != null) return sound;
            Debug.Log("Requesterd track: " + name + " not found!");
            return null;
        }
    }
}