using System;
using Services;
using UnityEngine;

namespace UI_View
{
    public class AudioToggler : MonoBehaviour
    {
        public bool isOn;
        public AudioSource click;
        private void Start()
        {
            isOn = true;
            click.Play();
        }

        public void OffSound()
        {
            if (!isOn)
            {
                AudioListener.volume = 1f;
                isOn = true;
            }
            else if (isOn)
            {
                AudioListener.volume = 0f;
                isOn = false;
            }
        }
    }
}