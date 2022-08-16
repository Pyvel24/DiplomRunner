using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class AudioService: IAudioService
    {
        private bool _mute;
        private float _volume = 1;
        private static Dictionary<string, Sound> _sounds;
        public AudioService(IEnumerable<Sound> sounds)
        {
            _sounds = sounds.ToDictionary(sound => sound.name);
        }

        public void Play(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var sound))
            {
                sound.source.Play();
            }
        }

        public void Stop(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var sound))
            {
                sound.source.Stop();
            }
        }

        public bool Mute
        {
            get => _mute;
            set
            {
                _mute = value;
                foreach (var sound in _sounds.Values)
                {
                    sound.source.Stop();
                }
            }
        }

        public float Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                foreach (var kv in _sounds)
                {
                    kv.Value.source.volume = _volume;
                }
            }
        }

        [Serializable]
        public class Sound
        {
            public string name;
            public AudioClip clip;
            [Range(0f, 1f)]
            public float pitch;
            public bool loop;
            [HideInInspector] 
            public AudioSource source;


        }
        
    }
}